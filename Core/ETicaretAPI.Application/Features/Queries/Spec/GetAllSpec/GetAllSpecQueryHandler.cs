using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Spec.GetAllSpec
{
    public class GetAllSpecQueryHandler : IRequestHandler<GetAllSpecQueryRequest, GetAllSpecQueryResponse>
    {
        readonly ISpecService _specService;
        readonly IMapper _mapper;

        public GetAllSpecQueryHandler(ISpecService specService, IMapper mapper)
        {
            _specService = specService;
            _mapper = mapper;
        }
        public async Task<GetAllSpecQueryResponse> Handle(GetAllSpecQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetAllSpecQueryResponse>(await _specService.GetAllSpecAsync());
        }
    }
}
