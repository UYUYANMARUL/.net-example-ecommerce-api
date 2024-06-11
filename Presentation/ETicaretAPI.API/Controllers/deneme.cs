
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Features.Commands.Category.CreateCategory;
using ETicaretAPI.Application.Features.Commands.Category.RemoveCategory;
using ETicaretAPI.Application.Features.Commands.Category.UpdateCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetAllCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetAllTopCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetByIdCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetSubCategories;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Data.Entity;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class denemeController : ControllerBase
    {
        readonly private IMediator _mediator;
        readonly private IProductReadRepository _productReadRepository;
        private readonly ETicaretAPIDbContext _context;

        public denemeController(IProductReadRepository productReadRepository, ETicaretAPIDbContext context)
        {
            _productReadRepository = productReadRepository;
            _context = context;
        }





        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _context.Products.Include(p => p.ProductSpecs).Select(c => new { c.Name, c.Description, c.ProductSpecs }).ToListAsync();
            Console.WriteLine(response);
            return Ok(response);
        }


    }
}
