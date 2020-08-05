using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FMM.Features.UserType.Commands;
using FMM.Features.UserType.Queries;

namespace FMM.Features.UserType
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        IMediator _mediator;

        public UserTypeController(IMediator mediator)
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
        public async Task<ActionResult> Post(UserTypeRequest dto)
        {
            await _mediator.Send(new CreateCommand(dto));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, UserTypeRequest dto)
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
