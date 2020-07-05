using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FMM.Persistent.Step;
using FMM.Features.Step.Commands;
using FMM.Features.Step.Queries;

namespace FMM.Features.Step
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepController : ControllerBase
    {

        IMediator _mediator;

        private static readonly IList<FMM.Persistent.Task> Tasks = new List<FMM.Persistent.Task>
        {
            new FMM.Persistent.Task{Id=Guid.NewGuid(), Description="First task", IsCompleted=false },
            new FMM.Persistent.Task{Id=Guid.NewGuid(), Description="Second task", IsCompleted=true }
        };

        private static readonly IList<FMM.Persistent.Step> Steps = new List<FMM.Persistent.Step>
        {
            
            new FMM.Persistent.Step {Id=Guid.NewGuid(), Description="First Step", Tasks=Tasks},
            new FMM.Persistent.Step{Id=Guid.NewGuid(), Description="Second Step"}
        };

        public StepController(IMediator mediator)
        {
            //_mediator = mediator;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(Steps);
        }

        /*
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }
        */
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid Id)
        {
            return Ok(Steps.FirstOrDefault(x => x.Id == Id));
        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetQuery(id)));
        }
        */
        
        [HttpPost]
        public ActionResult Post(FMM.Persistent.Step step)
        {
            Steps.Add(step);

            return NoContent();
        }

        /*
        [HttpPost]
        public async Task<ActionResult> Post(StepRequest dto)
        {
            await _mediator.Send(new CreateCommand(dto));
            return NoContent();
        }
        */
        
        [HttpPut]
        public ActionResult Put(FMM.Persistent.Step step)
        {
            var toUpdate = Steps.FirstOrDefault(x => x.Id == step.Id);
            toUpdate.Description = step.Description;
            toUpdate.Tasks = step.Tasks;
            toUpdate.IsCompleted = step.IsCompleted;

            return NoContent();
        }

        /*
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, StepRequest dto)
        {
            await _mediator.Send(new UpdateCommand(id, dto));
            return NoContent();
        }
        */
        
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var toRemove = Steps.FirstOrDefault(x => x.Id == id);
            Steps.Remove(toRemove);

            return NoContent();
        }
        
        /*
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCommand(id));
            return NoContent();
        }
        */
    }
}
