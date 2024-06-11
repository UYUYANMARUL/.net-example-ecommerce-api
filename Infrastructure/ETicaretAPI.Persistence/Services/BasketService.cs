
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Basket;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ETicaretAPI.Persistence.Services
{
    public class BasketService :IBasketService
    {
        private readonly IBasketItemWriteRepository _basketItemWriteRepository;
        private readonly IBasketItemReadRepository _basketItemReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly IEndpointReadRepository _endpointReadRepository;

        public BasketService(UserManager<AppUser> userManager,
            IEndpointReadRepository endpointReadRepository,
            IHttpContextAccessor httpContextAccessor,
            IBasketReadRepository basketReadRepository,
            IBasketWriteRepository basketWriteRepository,
            IBasketItemReadRepository basketItemReadRepository,
            IBasketItemWriteRepository basketItemWriteRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
        }

        private async Task<Basket?> GetContextUserBasket()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users.Include(B => B.Basket).ThenInclude(I => I.BasketItems).FirstOrDefaultAsync(x => x.UserName == username);
                return user.Basket;
            }
            throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }

        public async Task AddItemToBasketAsync(AddItemToBasketRequest request)
        {
            Basket? basket = await GetContextUserBasket();
            if (basket != null) {
                BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(BI => BI.BasketId == basket.Id && BI.ProductId == request.ProductId);
                if (_basketItem != null)
                    _basketItem.Quantity = _basketItem.Quantity + request.Quantity;
                else
                {
                    var result = await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    });
                }
                await _basketItemWriteRepository.SaveAsync();
             }
            else throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }


        public async Task RemoveBasketItemAsync(RemoveBasketItemRequest request)
        {
            Basket? basket = await GetContextUserBasket();
            BasketItem? basketItem = await _basketItemReadRepository.Table.FirstOrDefaultAsync(p => p.BasketId == basket.Id && p.Id == request.BasketItemId);
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateBasketItemQuantityAsync(UpdateBasketItemQuantityRequest request)
        {

            Basket? basket = await GetContextUserBasket();
            BasketItem? basketItem = await _basketItemReadRepository.Table.FirstOrDefaultAsync(p => p.BasketId == basket.Id && p.Id == request.BasketItemId);
            if (basketItem != null)
            {
                if (request.BasketItemQuantity == 0)
                {
                    _basketItemWriteRepository.Remove(basketItem);
                }
                else
                {
                basketItem.Quantity = request.BasketItemQuantity;
                await _basketItemWriteRepository.SaveAsync();
                }
            }
        }


        public async Task<Basket> GetBasketItemsAsync()
        {
            Basket? basket = await GetContextUserBasket();
            Basket? result = await _basketReadRepository.Table
                 .Include(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product)
                 .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result;
        }


        public async Task EmptyUsersBasket()
        {
            Basket? basket = await GetContextUserBasket();
            basket.BasketItems.Clear();
            await _basketWriteRepository.SaveAsync();
        }

    }
}

