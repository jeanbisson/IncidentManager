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
    public class ProfileController : ControllerBase
    {


        private readonly ILogger<ProfileController> logger;
        private readonly IncidentManagerDbContext dbContext;

        public ProfileController(ILogger<ProfileController> logger, IncidentManagerDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await dbContext.Profiles.ToListAsync();

          
            return Ok(profiles);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profile = await dbContext.Profiles.Where(a => a.Id == id).FirstOrDefaultAsync();

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profile profile)
        {
            dbContext.Add(profile);
            await dbContext.SaveChangesAsync();
            return Ok(profile);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Profile profile)
        {
            dbContext.Update(profile);
            await dbContext.SaveChangesAsync();
            return Ok(profile);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await dbContext.Profiles.Where(a => a.Id == id).FirstOrDefaultAsync();
            dbContext.Remove(profile);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
