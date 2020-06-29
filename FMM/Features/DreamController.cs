using System;
using System.Collections.Generic;
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
    }
}
