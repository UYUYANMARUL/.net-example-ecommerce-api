using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.SetPriceToOrder
{
    public class SetPriceToOrderCommandHandler : IRequestHandler<SetPriceToOrderCommandRequest, SetPriceToOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public SetPriceToOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<SetPriceToOrderCommandResponse> Handle(SetPriceToOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.SetPriceToOrder(_mapper.Map<SetPriceToOrderRequest>(request));
            return new();
        }
    }
}
