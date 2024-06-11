using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.AddOrderToOrderBlock
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public AddOrderCommandHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }



        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
           await _orderService.AddOrderToOrderBlockAsync(_mapper.Map<AddOrderToOrderBlockRequest>(request));
           return new();
        }
    }
}
