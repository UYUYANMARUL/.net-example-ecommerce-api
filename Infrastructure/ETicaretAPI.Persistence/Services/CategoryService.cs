using AutoMapper;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory;
using ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    class CategoryService : ICategoryService
    {
        readonly IMapper _mapper;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ISpecReadRepository _specReadRepository;
        public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, ISpecReadRepository specReadRepository)

        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _specReadRepository = specReadRepository;
        }
        public async Task<bool> CreateCategoryAsync(CreateCategoryRequest model)
        {

            List<SpecName> specs = await _specReadRepository.GetWhere(p => model.SpecNameId.Contains(p.Id)).ToListAsync();
            Category topcategory;
            if (model.topcategoryId != null)
            {
                topcategory = await _categoryReadRepository.GetByIdAsync(model.topcategoryId);
            }
            else topcategory = null;
            await _categoryWriteRepository.AddAsync(new()
            {
                SpecNames = specs,
                CategoryName = model.CategoryName,
                topcategory = topcategory,
                IsExsitSubCategory = false
            }); 
            if (topcategory != null)    
            {
                topcategory.IsExsitSubCategory = true;
            }
            await _categoryWriteRepository.SaveAsync();
            return true;
        }

        public async Task RemoveCategoryAsync(Guid id)
        {
            Category category = await _categoryReadRepository.GetByIdAsync(id);
            if (category == null) { throw new Exception(); }
            if (category.topcategoryId != null)
            {
                Category topcategory = await _categoryReadRepository.GetByIdAsync((Guid)category.topcategoryId);
                topcategory.IsExsitSubCategory = false;
            }
            await _categoryWriteRepository.SaveAsync();
            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryRequest model)
        {
            Category topcategory;
            if (model.Id != null)
            {
                topcategory = await _categoryReadRepository.GetByIdAsync(model.topcategoryId);
            }
            else topcategory = null;


            Category category = await _categoryReadRepository.GetByIdAsync(model.Id);
            category =new() {
                CategoryName = model.CategoryName,
                topcategory = topcategory,
            };
            if(topcategory != null)
            { topcategory.IsExsitSubCategory = true;}
            else
            {
                topcategory.IsExsitSubCategory = false;
            }
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var categories = _categoryReadRepository.GetAll(false).ToList();
            return categories;
        }   

        public async Task<List<Category>> GetAllTopCategoryAsync()
        {
            var categories = _categoryReadRepository.GetAll(false).Where(p => p.topcategory ==null).ToList();
            
            return categories;
        }

        public async Task<List<Category>> GetSubCategoriesAsync(Guid CategoryId)
        {
            var categories = _categoryReadRepository.GetAll(false).Where(p => p.topcategory.Id == CategoryId).ToList();
            return categories;
        }

        public async Task<Category> GetByIdCategoryAsync(Guid CategoryId)
        {
            Category category = await _categoryReadRepository.Table.Include(p => p.SpecNames).FirstOrDefaultAsync(p => p.Id == CategoryId);
            return category;
        }

        public async Task<GetSearchCategoryQueryResponse> GetSearchCategoryAsync(GetSearchCategoryRequest request)
        {

            var categories = _categoryReadRepository.GetWhere(p => p.CategoryName.Contains(request.SearchValue), false).Take(request.DataSize)
.ToList();
            return new()
            {
                TotalCategoryCount = 5,
                Categories = categories,
            };
        }


        public async Task<HashSet<Guid>> GetAllSpecIdInListedCategoriesAsync(Guid Id)
        {
            var categoryId = "";

            if (Id != null)
                categoryId = Id.ToString();

            var array = new HashSet<Guid>();
            var CategorySpecs = await _categoryReadRepository.GetWhere(p => p.Id.ToString().Contains(categoryId), false).Select(x => new { x.SpecNames }).ToListAsync();
            foreach (var Specs in CategorySpecs) foreach (SpecName spec in Specs.SpecNames)
                {
                    if (!array.Contains(spec.Id)) array.Add(spec.Id);
                }
            return array;
        }


    }
}
