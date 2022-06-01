using BookingMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingMicroservice.Database
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<BranchExternal>? Branches { get; set; }
        public DbSet<CompanyExternal>? Companies { get; set; }
        public DbSet<EmployeeExternal>? Employees { get; set; }
        public DbSet<ServiceExternal>? Services { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }
    }
}
