using IncidentManager.Shared;
using Microsoft.EntityFrameworkCore;

namespace IncidentManager.Server.Dal
{
    public class IncidentManagerDbContext : DbContext
    {
        public IncidentManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProgramBranch> ProgramBranches { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Incident> Incidents { get; set; }


    }

}
