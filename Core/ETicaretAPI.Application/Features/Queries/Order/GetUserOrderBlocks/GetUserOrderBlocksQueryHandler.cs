using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetUserOrderBlocks
{
    public class GetUserOrderBlocksQueryHandler : IRequestHandler<GetUserOrderBlocksQueryRequest, GetUserOrderBlocksQueryResponse>
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public GetUserOrderBlocksQueryHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<GetUserOrderBlocksQueryResponse> Handle(GetUserOrderBlocksQueryRequest request, CancellationToken cancellationToken)
        {
            GetUserOrderBlocksQueryResponse response = await _orderService.GetUserOrderBlocksAsync(request);
            return response;
        }
    }
}
