using AutoMapper;
using BookingMicroservice.Dto.Export;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBookingController : ControllerBase
    {
        private readonly ICustomerBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public CustomerBookingController(
            ICustomerBookingRepository bookingRepository,
            IMapper mapper
        )
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetBookingInfo(int id)
        {
            Booking? booking = await _bookingRepository.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerBookingDetailsDto>(booking));
        }

        [HttpGet(template: "upcoming/branch/{branchId}")]
        public async Task<IActionResult> GetUpcomingSessions(int branchId)
        {
            int userId = 0; // id from auth context
            List<Booking>? bookings = await _bookingRepository
                .GetUpcomingSessions(userId, branchId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CustomerBookingShortInfoDto>>(bookings));
        }

        [HttpGet(template: "past/branch/{branchId}")]
        public async Task<IActionResult> GetPastSessions(int branchId)
        {
            int userId = 0;
            List<Booking>? bookings = await _bookingRepository
                .GetPastSessions(userId, branchId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CustomerBookingShortInfoDto>>(bookings));
        }
    }
}
