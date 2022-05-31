using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Database
{
    public class OrgStructDbContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Branch>? Branches { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<WorkDay>? WorkDays { get; set; }
        public DbSet<TimeUnit>? TimeUnits { get; set; }

        public OrgStructDbContext(DbContextOptions<OrgStructDbContext> options) : base(options)
        {
        }
    }
}
