using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Basket.UpdateBasketItemQuantity
{
    public class UpdateBasketItemQuantityCommandHandler : IRequestHandler<UpdateBasketItemQuantityCommandRequest, UpdateBasketItemQuantityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBasketService _basketService;

        public UpdateBasketItemQuantityCommandHandler(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<UpdateBasketItemQuantityCommandResponse> Handle(UpdateBasketItemQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateBasketItemQuantityAsync(_mapper.Map<UpdateBasketItemQuantityRequest>(request));
            return new();
        }
    }
}
