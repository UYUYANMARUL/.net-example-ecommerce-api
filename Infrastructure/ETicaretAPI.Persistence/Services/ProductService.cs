using AutoMapper;
using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetFilteredProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    class ProductService : IProductService
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly ISpecReadRepository _specReadRepository;
        readonly IProductHubService _productHubService;
        readonly ICategoryService _categoryService;
        readonly ETicaretAPIDbContext _context;
        readonly IMapper _mapper;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, IProductHubService productHubService, ISpecReadRepository specReadRepository, ETicaretAPIDbContext context, ICategoryService categoryService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _productHubService = productHubService;

            _specReadRepository = specReadRepository;
            _context = context;
            _categoryService = categoryService;
        }

        public async Task<bool> CreateProductAsync(CreateProductRequest model)
        {

            Category category = await _categoryService.GetByIdCategoryAsync(model.CategoryId);

            
            var array = new List<ProductSpec>();
            foreach (var spec in model.Specs)
            { 
                SpecName data = await _specReadRepository.GetSingleAsync(p => p.Id == spec.SpecId);
                if (!float.TryParse(spec.Value, out _))
                {
                    throw new Exception("expected type float"); //expected type float
                }
                array.Add(new ProductSpec { SpecName = data, Value = spec.Value });
            }



            await _productWriteRepository.AddAsync(new()
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                ProductSpecs = array
            });
            await _productWriteRepository.SaveAsync();
            await _productHubService.ProductAddedMessageAsync("sa");
            return new();
        }

        public async Task DeleteProductAsync(Guid ProductId)
        {
            await _productWriteRepository.RemoveAsync(ProductId);
            await _productWriteRepository.SaveAsync();
        }

        public async Task<GetAllProductQueryResponse> GetAllProductAsync(GetAllProductRequest request)
        {
            var totalProductCount = _productReadRepository.GetAll(false).Count();

            var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToList();
            return new()
            {
                Products = products,
                TotalProductCount = totalProductCount
            };

        }

        public async Task<HashSet<Guid>> GetAllSpecIdInListedProductsAsync(GetAllSpecIdInListedProductsRequest request)
        {
            Category category = await _categoryService.GetByIdCategoryAsync(request.CategoryId);

            HashSet<Guid>? categoryspecarray = await _categoryService.GetAllSpecIdInListedCategoriesAsync(request.CategoryId);
            var categoryName = "";
            if (category != null)
                categoryName = request.CategoryId.ToString();

            var array = new HashSet<Guid>();
            var products = _productReadRepository.GetWhere(p => p.Category!.Id.ToString().Contains(categoryName) & ((p.Name.Contains(request.SearchKey) | p.Code.Contains(request.SearchKey))), false).Select(x => new { x.ProductSpecs }).ToList();
            foreach (var product in products) foreach (ProductSpec spec in product.ProductSpecs!)
                {
                    if (!array.Contains(spec.SpecNameId)) array.Add(spec.SpecNameId);
                }
            foreach (Guid id in categoryspecarray) array.Add(id);

            return array;
        }

        public async Task UpdateProductAsync(UpdateProductRequest model)
        {
            Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.CategoryId = model.CategoryId;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Code = model.Code;

            await _productWriteRepository.SaveAsync();
        }

        public async Task<GetSearchProductQueryResponse> GetSearchProductAsync(GetSearchProductRequest request)
        {

            var products = _productReadRepository.GetWhere(p => p.Name.Contains(request.SearchValue) | p.Code.Contains(request.SearchValue), false).Take(request.DataSize)
.ToList();
            return new()
            {
                TotalProductCount = 5,
                Products = products,
            };
        }

        public Task<GetFilteredProductQueryResponse> GetFilteredProductAsync(GetFilteredProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
