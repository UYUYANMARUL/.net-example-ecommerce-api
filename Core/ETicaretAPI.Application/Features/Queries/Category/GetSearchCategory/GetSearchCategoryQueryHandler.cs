using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory
{
    public class GetSearchCategoryQueryHandler : IRequestHandler<GetSearchCategoryQueryRequest, GetSearchCategoryQueryResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetSearchCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<GetSearchCategoryQueryResponse> Handle(GetSearchCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetSearchCategoryAsync(_mapper.Map<GetSearchCategoryRequest>(request));

            return result;
        }
    }
}
