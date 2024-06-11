using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Order.AddOrderToOrderBlock;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Commands.Order.SetPriceToOrder;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Queries.Order.GetUserOrderBlocks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SetPriceToOrder(SetPriceToOrderCommandRequest setPriceToOrderCommandRequest)
        {
            SetPriceToOrderCommandResponse response = await _mediator.Send(setPriceToOrderCommandRequest);
            return Ok(response);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsersOrderBlocks([FromQuery] GetUserOrderBlocksQueryRequest getUserOrderBlocksQueryRequest)
        {
            GetUserOrderBlocksQueryResponse response = await _mediator.Send(getUserOrderBlocksQueryRequest);
            return Ok(response);

        }
    }
}
