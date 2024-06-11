using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CreateCategoryRequest model);
        Task RemoveCategoryAsync(Guid CategoryId);
        Task UpdateCategoryAsync(UpdateCategoryRequest model);

        Task<List<Category>> GetAllTopCategoryAsync();
        Task<List<Category>> GetSubCategoriesAsync(Guid CategoryId);
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetByIdCategoryAsync(Guid CategoryId);

        Task<HashSet<Guid>> GetAllSpecIdInListedCategoriesAsync(Guid Id);
        Task<GetSearchCategoryQueryResponse> GetSearchCategoryAsync(GetSearchCategoryRequest request);
    }
}
