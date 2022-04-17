using IncidentManager.Server.Dal;
using IncidentManager.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramBranchController : ControllerBase
    {


        private readonly ILogger<ProgramBranchController> logger;
        private readonly IncidentManagerDbContext dbContext;

        public ProgramBranchController(ILogger<ProgramBranchController> logger, IncidentManagerDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var programBranches = await dbContext.ProgramBranches.ToListAsync();

          
            return Ok(programBranches);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var programBranch = await dbContext.ProgramBranches.Where(a => a.Id == id).FirstOrDefaultAsync();

            return Ok(programBranch);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProgramBranch programBranch)
        {
            dbContext.Add(programBranch);
            await dbContext.SaveChangesAsync();
            return Ok(programBranch);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProgramBranch updatedProgramBranch)
        {
            dbContext.Update(updatedProgramBranch);
            await dbContext.SaveChangesAsync();
            return Ok(updatedProgramBranch);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var programBranch = await dbContext.ProgramBranches.Where(a => a.Id == id).FirstOrDefaultAsync();
            dbContext.Remove(programBranch);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
