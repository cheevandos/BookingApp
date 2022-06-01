using AutoMapper;
using BookingMicroservice.Dto.Export;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBookingController : ControllerBase
    {
        private readonly IEmployeeBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public EmployeeBookingController(
            IEmployeeBookingRepository bookingRepository,
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

            return Ok(_mapper.Map<EmployeeBookingDetailsDto>(booking));
        }

        [HttpGet(template: "upcoming/branch/{branchId}/employee/{employeeId}")]
        public async Task<IActionResult> GetUpcomingSessions(int branchId, int employeeId)
        {
            List<Booking>? bookings = await _bookingRepository
                .GetUpcomingSessions(employeeId, branchId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<EmployeeBookingShortInfoDto>>(bookings));
        }

        [HttpGet(template: "past/branch/{branchId}/employee/{employeeId}")]
        public async Task<IActionResult> GetPastSessions(int branchId, int employeeId)
        {
            List<Booking>? bookings = await _bookingRepository
                .GetPastSessions(employeeId, branchId);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<EmployeeBookingShortInfoDto>>(bookings));
        }
    }
}
