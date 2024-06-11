﻿using AutoMapper;
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

namespace ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct
{
    public class GetSearchProductQueryHandler : IRequestHandler<GetSearchProductQueryRequest, GetSearchProductQueryResponse>
    {
        readonly IProductService _productService;
        readonly IMapper _mapper;
        public GetSearchProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<GetSearchProductQueryResponse> Handle(GetSearchProductQueryRequest request, CancellationToken cancellationToken)
        {

            var result = await _productService.GetSearchProductAsync(_mapper.Map<GetSearchProductRequest>(request));

            return result;
        }
    }
}