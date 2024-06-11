using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using X = ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Category.GetAllTopCategory
{
    public class GetAllTopCategoryQueryHandler : IRequestHandler<GetAllTopCategoryQueryRequest, GetAllTopCategoryQueryResponse>
    {
        readonly IMapper _mapper;
        readonly ICategoryService _categoryService;
        public GetAllTopCategoryQueryHandler(ICategoryService categoryService,IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }   

        public async Task<GetAllTopCategoryQueryResponse> Handle(GetAllTopCategoryQueryRequest request, CancellationToken cancellationToken)
        {
          List<X.Category> result = await _categoryService.GetAllTopCategoryAsync();
            return new() { Category = result };

        }
    }
 }
 