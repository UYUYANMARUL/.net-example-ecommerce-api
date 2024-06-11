using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Queries.Order.GetUserOrderBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
   public interface IOrderService
    {
        Task CreateOrder(CreateOrderRequest request);
        Task AddOrderToOrderBlockAsync(AddOrderToOrderBlockRequest request);
        Task SetPriceToOrder(SetPriceToOrderRequest request);
        Task<GetUserOrderBlocksQueryResponse> GetUserOrderBlocksAsync(GetUserOrderBlocksQueryRequest request);
    }
}
