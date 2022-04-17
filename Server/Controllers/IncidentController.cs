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
    public class IncidentController : ControllerBase
    {


        private readonly ILogger<IncidentController> logger;
        private readonly IncidentManagerDbContext dbContext;

        public IncidentController(ILogger<IncidentController> logger, IncidentManagerDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try { 
            var incidents = await dbContext.Incidents.ToListAsync();
                return Ok(incidents);

            }
            catch
            {
                //crashes when null for some reason
            }


            return Ok(null);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await dbContext.Incidents.Where(a => a.Id == id).FirstOrDefaultAsync();

            return Ok(incident);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Incident incident)
        {
            try
            {
            dbContext.Add(incident);
            await dbContext.SaveChangesAsync();
            return Ok(incident);

            }
            catch
            {

            }
            return NotFound();
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Incident incident)
        {
            dbContext.Update(incident);
            await dbContext.SaveChangesAsync();
            return Ok(incident);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var incident = await dbContext.Incidents.Where(a => a.Id == id).FirstOrDefaultAsync();
            dbContext.Remove(incident);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
