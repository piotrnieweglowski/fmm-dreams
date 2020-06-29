using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FMM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DreamController : ControllerBase
    {
        private static readonly IList<Dream> Dreams = new List<Dream>
        {
            new Dream { Id = Guid.NewGuid(), Title = "First Dream" },
            new Dream { Id = Guid.NewGuid(), Title = "Second Dream" }
        };


        public DreamController()
        {
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(Dreams);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid Id)
        {
            return Ok(Dreams.FirstOrDefault(x => x.Id == Id));
        }

        [HttpPost]
        public ActionResult Post(Dream dream)
        {
            Dreams.Add(dream);

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(Dream dream)
        {
            var toUpdate = Dreams.First(x => x.Id == dream.Id);
            toUpdate.Title = dream.Title;
            toUpdate.Description = dream.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var toRemove = Dreams.First(x => x.Id == id);
            Dreams.Remove(toRemove);

            return NoContent();
        }
    }
}
