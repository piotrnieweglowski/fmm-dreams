using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMM.Persistent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMM.Features.Dream
{
    [ApiController]
    [Route("api/[controller]")]
    public class DreamController : ControllerBase
    {
        DataContext _dbContext;

        public DreamController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dbContext.Dreams.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid Id)
        {
            return Ok(await _dbContext.Dreams.FirstOrDefaultAsync(x => x.Id == Id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(FMM.Persistent.Dream dream)
        {
            await _dbContext.Dreams.AddAsync(dream);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put(FMM.Persistent.Dream dream)
        {
            var toUpdate = await _dbContext.Dreams.FirstAsync(x => x.Id == dream.Id);
            toUpdate.Title = dream.Title;
            toUpdate.Description = dream.Description;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var toRemove = await _dbContext.Dreams.FirstAsync(x => x.Id == id);
            _dbContext.Dreams.Remove(toRemove);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
