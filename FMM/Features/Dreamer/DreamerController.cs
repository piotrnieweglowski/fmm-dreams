using System;
using System.Threading.Tasks;
using FMM.Features.Dreamer.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FMM.Features.Dreamer.Queries;

namespace FMM.Features.Dreamer
{
    [ApiController]
    [Route("api/[controller]")]
    public class DreamerController : ControllerBase
    {
        IMediator _mediator;

        public DreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(DreamerRequest dto)
        {
            await _mediator.Send(new CreateCommand(dto));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, DreamerRequest dto)
        {
            await _mediator.Send(new UpdateCommand(id, dto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCommand(id));
            return NoContent();
        }
    }
}
