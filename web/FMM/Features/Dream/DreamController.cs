﻿using System;
using System.Threading.Tasks;
using FMM.Features.Dream.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FMM.Features.Dream.Queries;
using Microsoft.AspNetCore.Authorization;
using FMM.Common;

namespace FMM.Features.Dream
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class DreamController : ControllerBase
    {
        IMediator _mediator;

        public DreamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] DreamFilter filter, [FromQuery] PagingOptions pagingOptions)
        {
            return Ok(await _mediator.Send(new GetAllQuery(filter, pagingOptions)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(DreamRequest dto)
        {
            await _mediator.Send(new CreateCommand(dto));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, DreamRequest dto)
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
