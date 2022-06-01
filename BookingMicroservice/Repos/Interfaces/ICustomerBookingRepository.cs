using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface ICustomerBookingRepository : IBookingRepositoryBase
    {
        Task<List<Booking>?> GetUpcomingSessions(int userId, int branchId);
        Task<List<Booking>?> GetPastSessions(int userId, int branchId);

        Task<List<Booking>?> GetUpcomingEmployeeSessions(int employeeId, int branchId);
        Task<List<Booking>?> GetPastEmployeeSessions(int employeeId, int branchId);

        Task CreateBooking(Booking newBooking);
    }
}