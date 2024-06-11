using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Basket.AddItemToBasket;
using ETicaretAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using ETicaretAPI.Application.Features.Commands.Basket.UpdateBasketItemQuantity;
using ETicaretAPI.Application.Features.Commands.Category.UpdateCategory;
using ETicaretAPI.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "AddItemToCurrentUserBasket", Menu = "Basket")]
        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }

        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "GetCurrentUserBasket", Menu = "Basket")]
        [HttpGet]
        public async Task<IActionResult> GetBasket([FromQuery] GetUserBasketQueryRequest getUserBasketQueryRequest)
        {
            GetUserBasketQueryResponse response = await _mediator.Send(getUserBasketQueryRequest);
            return Ok(response);
        }

        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "UpdateCurrentUserBasketItemQuantity", Menu = "Basket")]
        [HttpPut]
        public async Task<IActionResult> UpdateBasketItemQuantity(UpdateBasketItemQuantityCommandRequest updateBasketItemQuantityCommandRequest)
        {
            UpdateBasketItemQuantityCommandResponse response = await _mediator.Send(updateBasketItemQuantityCommandRequest);
            return Ok(response);
        }

        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "DeleteCurrentUserBasketItem", Menu = "Basket")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem(RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(response);
        }

    }
}
