
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Features.Commands.Category.CreateCategory;
using ETicaretAPI.Application.Features.Commands.Category.RemoveCategory;
using ETicaretAPI.Application.Features.Commands.Category.UpdateCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetAllCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetAllTopCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetByIdCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetSubCategories;
using ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        readonly private IMediator _mediator;
        readonly private ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService,
            IMediator mediator)

        {
            _categoryService = categoryService;
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Delete(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(removeCategoryCommandRequest);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTopCategories([FromQuery] GetAllTopCategoryQueryRequest getAllTopCategoryQueryRequest)
        {
            GetAllTopCategoryQueryResponse response = await _mediator.Send(getAllTopCategoryQueryRequest);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetSearch([FromQuery] GetSearchCategoryQueryRequest getSearchCategoryQueryRequest)
        {
            GetSearchCategoryQueryResponse response = await _mediator.Send(getSearchCategoryQueryRequest);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSubCategories([FromQuery] GetSubCategoriesQueryRequest getSubCategoriesQueryRequest)
        {
            GetSubCategoriesQueryResponse response = await _mediator.Send(getSubCategoriesQueryRequest);
            return Ok(response);

        }

    }
}
