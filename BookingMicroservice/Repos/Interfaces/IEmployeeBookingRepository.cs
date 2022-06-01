using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface IEmployeeBookingRepository : IBookingRepositoryBase
    {
        Task<List<Booking>?> GetUpcomingSessions(int employeeId, int branchId);
        Task<List<Booking>?> GetPastSessions(int employeeId, int branchId);
    }
}
