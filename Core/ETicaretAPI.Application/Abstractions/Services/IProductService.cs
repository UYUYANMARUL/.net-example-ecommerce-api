using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetFilteredProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(CreateProductRequest model);
        Task DeleteProductAsync(Guid ProductId);
        Task UpdateProductAsync(UpdateProductRequest model);
        Task<GetAllProductQueryResponse> GetAllProductAsync(GetAllProductRequest request);
        Task<GetFilteredProductQueryResponse> GetFilteredProductAsync(GetFilteredProductRequest request);
        Task<GetSearchProductQueryResponse> GetSearchProductAsync(GetSearchProductRequest request);
        Task<HashSet<Guid>> GetAllSpecIdInListedProductsAsync(GetAllSpecIdInListedProductsRequest request);

    }
}
