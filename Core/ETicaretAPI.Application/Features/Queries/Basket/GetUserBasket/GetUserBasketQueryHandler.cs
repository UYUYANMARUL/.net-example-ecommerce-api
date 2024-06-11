using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries
{
    public class GetUserBasketQueryHandler : IRequestHandler<GetUserBasketQueryRequest, GetUserBasketQueryResponse>
    {
        readonly private IBasketService _basketService;

        public GetUserBasketQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<GetUserBasketQueryResponse> Handle(GetUserBasketQueryRequest request, CancellationToken cancellationToken)
        {
            Basket basket = await _basketService.GetBasketItemsAsync();
            return new() { Basket = basket };
        }
    }
}
