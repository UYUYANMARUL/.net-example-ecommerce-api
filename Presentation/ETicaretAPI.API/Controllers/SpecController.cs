
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Specs.CreateSpec;
using ETicaretAPI.Application.Features.Commands.Specs.DeleteSpec;
using ETicaretAPI.Application.Features.Queries.Spec.GetAllSpec;
using ETicaretAPI.Application.Features.Queries.Spec.GetSpecList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ETicaretAPI.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class SpecController : ControllerBase
    {
        readonly private IMediator _mediator;
        readonly private ISpecService _specService;

        public SpecController(
            ISpecService specService,
            IMediator mediator)

        {
            _specService = specService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSpecCommandRequest createSpecCommandRequest)
        {
            CreateSpecCommandResponse response = await _mediator.Send(createSpecCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSpecCommandRequest deleteSpecCommandRequest)
        {
            DeleteSpecCommandResponse response = await _mediator.Send(deleteSpecCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSpecQueryRequest getAllSpecQueryRequest)
        {
            GetAllSpecQueryResponse response = await _mediator.Send(getAllSpecQueryRequest);
            return Ok(response);
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetListSpecs([FromQuery] GetSpecListQueryRequest getSpecListQueryRequest)
        {
            GetSpecListQueryResponse response = await _mediator.Send(getSpecListQueryRequest);
            return Ok(response);
        }
    }
}
