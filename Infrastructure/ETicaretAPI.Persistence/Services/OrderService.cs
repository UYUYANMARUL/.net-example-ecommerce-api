using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Queries.Order.GetUserOrderBlocks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class OrderService :IOrderService
    {
        private readonly IOrderBlockReadRepository _orderBlockReadRepository;
        private readonly IOrderBlockWriteRepository _orderBlockWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderItemReadRepository _orderItemReadRepository;
        private readonly IOrderItemWriteRepository _orderItemWriteRepository;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;




        public OrderService
            (IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IOrderBlockWriteRepository orderBlockWriteRepository,
            IOrderBlockReadRepository orderBlockReadRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            IOrderItemWriteRepository orderItemWriteRepository,
            IOrderItemReadRepository orderItemReadRepository,
            IBasketService basketService)

        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderBlockWriteRepository = orderBlockWriteRepository;
            _orderBlockReadRepository = orderBlockReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderItemWriteRepository = orderItemWriteRepository;
            _orderItemReadRepository = orderItemReadRepository;
            _basketService = basketService;
        }

        private async Task<AppUser> GetContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users.Include(B => B.Basket).ThenInclude(I => I.BasketItems).ThenInclude(p=>p.Product).FirstOrDefaultAsync(x => x.UserName == username);
                return user!;
            }
            throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }

        public async Task CreateOrder(CreateOrderRequest request)
        {
            AppUser user = await GetContextUser();
            List<OrderItem> orderItems = new List<OrderItem>();
            if (user.Basket.BasketItems.Count() == 0) throw new Exception();
            foreach (var item in user.Basket.BasketItems)
            {
                orderItems.Add(new OrderItem
                {
                    Product = item.Product,
                    Piece = item.Quantity
                });
            }
            List<Order> orders = new List<Order>();
            Order order = new Order
            {
                OrderItems = orderItems,
                Description = request.Description,
                Address = request.Adress
            };
            orders.Add(order);
            await _orderBlockWriteRepository.AddAsync(new OrderBlock { AppUserId = user.Id, Order = orders });
            await _basketService.EmptyUsersBasket();
            await _orderBlockWriteRepository.SaveAsync();
        }


        public async Task SetPriceToOrder(SetPriceToOrderRequest request)
        {
            List<Guid> requestOrderItemsId = request.OrderItems.Select(x => x.OrderItemId).ToList();
            float Price = 0;
            Order? order = await _orderReadRepository.Table.Include(o=>o.OrderItems).FirstOrDefaultAsync(x=>x.Id == request.OrderId);
            if (order == null) throw new NotFoundOrderException();  //if order == null throw error that says there is not any order in database that matches request.id
            OrderBlock orderBlock = await _orderBlockReadRepository.GetByIdAsync(order.OrderBlockId);
            if (orderBlock == null) throw new ArgumentException(nameof(order)); //  if orderBlock is null throw error there is unknown error
            if (orderBlock.Cancelled == true) throw new ArgumentException(nameof(order));  //if orderBlock is closed throw error orderBlock is closed
            if (order.IsValid == false) throw new ArgumentException(nameof(order)); // if order.isvalid == false throw error this order is closed
            foreach(var item in order.OrderItems)
            {
                if(!requestOrderItemsId.Contains(item.Id)) throw new ArgumentException(nameof(order));  //if all request items id and order orderitem ids not match throw error
            }
            foreach (var requestOrderItem in request.OrderItems) {
                OrderItem orderItem = await _orderItemReadRepository.GetByIdAsync(requestOrderItem.OrderItemId);
                if (orderItem == null) throw new ArgumentException(nameof(order));  //could not found orderItem related to requestOrderItem.OrderItemId
                if (!order.OrderItems.Contains(orderItem)) throw new ArgumentException(nameof(order)); // these ids are not in that order
                orderItem.PiecePrice = requestOrderItem.PiecePrice;
                Price += orderItem.Piece * requestOrderItem.PiecePrice;
            }
            order.TotalPrice = Price;
            await _orderBlockWriteRepository.SaveAsync();
            await _orderItemWriteRepository.SaveAsync();
        }

        public async Task AddOrderToOrderBlockAsync(AddOrderToOrderBlockRequest request)
        {
            
           AppUser user = await GetContextUser();
           var matchedBlockWithUser = user.OrderBlocks.Contains(await _orderBlockReadRepository.GetByIdAsync(request.OrderBlockId));
           if(matchedBlockWithUser)
            {

            }
        }


        public async Task<GetUserOrderBlocksQueryResponse> GetUserOrderBlocksAsync(GetUserOrderBlocksQueryRequest request)
        {
            AppUser user = await GetContextUser();
            List<OrderBlock> orderBlocks = await _orderBlockReadRepository.GetWhere(p => p.AppUserId == user!.Id).Include(p=>p.Order).ThenInclude(p=>p.OrderItems).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            return new()
            {
                OrderBlocks = orderBlocks,
                TotalOrderBlocksCount = orderBlocks.Count()
            };
        }

        public async Task GetQueryOrderBlockAsync() { }
    }
}
