using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Spec.GetSpecList
{
    public class GetSpecListQueryHandler : IRequestHandler<GetSpecListQueryRequest, GetSpecListQueryResponse>
    {
        readonly IMapper _mapper;
        readonly ISpecService _specService;

        public GetSpecListQueryHandler(ISpecService specService, IMapper mapper)
        {
            _specService = specService;
            _mapper = mapper;
        }

        public async Task<GetSpecListQueryResponse> Handle(GetSpecListQueryRequest request, CancellationToken cancellationToken)
        {
            GetSpecListResponse data = await _specService.GetSpecListAsync(_mapper.Map<GetSpecListRequest>(request));
            var specs = _mapper.Map<GetSpecListQueryResponse>(data);
            return specs;
        }
    }
}
