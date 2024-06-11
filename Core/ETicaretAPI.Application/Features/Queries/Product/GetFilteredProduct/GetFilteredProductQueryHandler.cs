using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetFilteredProduct
{
    public class GetFilteredProductQueryHandler : IRequestHandler<GetFilteredProductQueryRequest, GetFilteredProductQueryResponse>
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;
        public GetFilteredProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<GetFilteredProductQueryResponse> Handle(GetFilteredProductQueryRequest request, CancellationToken cancellationToken)
        {

            var result = await _productService.GetFilteredProductAsync(_mapper.Map<GetFilteredProductRequest>(request));

            return result;
        }
    }
}