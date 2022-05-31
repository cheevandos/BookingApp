using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface IBookingRepository : IRepositoryBase
    {
        Task<List<Booking>?> GetUpcomingUserSessions(int userId, int branchId);
        Task<List<Booking>?> GetPastUserSessions(int userId, int branchId);
        Task<Booking?> GetBooking(int id);
        Task CreateBooking(Booking newBooking);
    }
}