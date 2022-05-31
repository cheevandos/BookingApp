using BookingMicroservice.Database;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;

namespace BookingMicroservice.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task CreateBooking(Booking newBooking)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>?> GetPastUserSessions(int userId, int branchId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>?> GetUpcomingUserSessions(int userId, int branchId)
        {
            throw new NotImplementedException();
        }
    }
}
