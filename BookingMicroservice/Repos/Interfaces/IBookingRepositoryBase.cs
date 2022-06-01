using BookingMicroservice.Models;

namespace BookingMicroservice.Repos.Interfaces
{
    public interface IBookingRepositoryBase : IRepositoryBase
    {
        Task<Booking?> GetBooking(int id);
    }
}
