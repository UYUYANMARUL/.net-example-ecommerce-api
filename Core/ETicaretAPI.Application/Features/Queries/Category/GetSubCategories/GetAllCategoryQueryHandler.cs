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

namespace ETicaretAPI.Application.Features.Queries.Category.GetSubCategories
{
    public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQueryRequest, GetSubCategoriesQueryResponse>
    {
        readonly IMapper _mapper;
        readonly ICategoryService _categoryService;
        public GetSubCategoriesQueryHandler(ICategoryService categoryService,IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }   

        public async Task<GetSubCategoriesQueryResponse> Handle(GetSubCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
          List<X.Category> result = await _categoryService.GetSubCategoriesAsync(request.Id);
            return new() { Category = result };

        }
    }
 }
 