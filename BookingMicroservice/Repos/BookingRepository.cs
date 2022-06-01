using BookingMicroservice.Database;
using BookingMicroservice.Enums;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingMicroservice.Repos
{
    public class BookingRepository : ICustomerBookingRepository, IEmployeeBookingRepository
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

        public async Task CreateBooking(Booking newBooking)
        {
            if (_context.Bookings != null)
            {
                await _context.Bookings.AddAsync(newBooking);
            }
        }

        public async Task<Booking?> GetBooking(int id)
        {
            if (_context.Bookings != null)
            {
                return await _context.Bookings
                    .FirstOrDefaultAsync(booking => booking.Id == id);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Booking>?> GetPastEmployeeSessions(int employeeId, int branchId)
        {
            if (_context.Bookings != null && _context.Employees != null)
            {
                List<Booking>? bookings = await _context.Bookings
                    .Include(booking => booking.EmployeeExternal)
                    .Include(booking => booking.BranchExternal)
                    .Include(booking => booking.CompanyExternal)
                    .Include(booking => booking.Services)
                    .Where(booking => 
                        booking.EmployeeExternalId == employeeId && 
                        booking.BranchExternalId == branchId &&
                        (
                            booking.Status == BookingStatus.Cancelled &&
                            booking.Status == BookingStatus.Rejected &&
                            booking.Status == BookingStatus.Completed
                        )
                    )
                    .OrderByDescending(booking => booking.DateTime)
                    .ToListAsync();

                return bookings.Any() ? bookings : null;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Booking>?> GetPastSessions(int userId, int branchId)
        {
            if (_context.Bookings != null)
            {
                List<Booking>? bookings = await _context.Bookings
                    .Include(booking => booking.EmployeeExternal)
                    .Include(booking => booking.BranchExternal)
                    .Include(booking => booking.CompanyExternal)
                    .Include(booking => booking.Services)
                    .Where(booking =>
                        booking.UserId == userId &&
                        booking.BranchExternalId == branchId &&
                        (
                            booking.Status == BookingStatus.Cancelled ||
                            booking.Status == BookingStatus.Rejected ||
                            booking.Status == BookingStatus.Completed
                        )
                    )
                    .OrderByDescending(booking => booking.DateTime)
                    .ToListAsync();

                return bookings.Any() ? bookings : null;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Booking>?> GetUpcomingEmployeeSessions(int employeeId, int branchId)
        {
            if (_context.Bookings != null && _context.Employees != null)
            {
                List<Booking>? bookings = await _context.Bookings
                    .Include(booking => booking.EmployeeExternal)
                    .Include(booking => booking.BranchExternal)
                    .Include(booking => booking.CompanyExternal)
                    .Include(booking => booking.Services)
                    .Where(booking =>
                        booking.EmployeeExternalId == employeeId &&
                        booking.BranchExternalId == branchId &&
                        (
                            booking.Status == BookingStatus.Pending ||
                            booking.Status == BookingStatus.Confirmed
                        )
                    )
                    .OrderByDescending(booking => booking.DateTime)
                    .ToListAsync();

                return bookings.Any() ? bookings : null;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Booking>?> GetUpcomingSessions(int userId, int branchId)
        {
            if (_context.Bookings != null)
            {
                List<Booking>? bookings = await _context.Bookings
                    .Include(booking => booking.EmployeeExternal)
                    .Include(booking => booking.BranchExternal)
                    .Include(booking => booking.CompanyExternal)
                    .Include(booking => booking.Services)
                    .Where(booking =>
                        booking.UserId == userId &&
                        booking.BranchExternalId == branchId &&
                        (
                            booking.Status == BookingStatus.Pending ||
                            booking.Status == BookingStatus.Confirmed
                        )
                    )
                    .OrderByDescending(booking => booking.DateTime)
                    .ToListAsync();

                return bookings.Any() ? bookings : null;
            }
            else
            {
                return null;
            }
        }
    }
}
