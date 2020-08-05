using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FMM.Features.Department.Commands;
using FMM.Features.Department.Queries;

namespace FMM.Features.Department
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        IMediator _mediator;

        public DepartmentController(IMediator mediator)
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
        public async Task<ActionResult> Post(DepartmentRequest dto)
        {
            await _mediator.Send(new CreateCommand(dto));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, DepartmentRequest dto)
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
