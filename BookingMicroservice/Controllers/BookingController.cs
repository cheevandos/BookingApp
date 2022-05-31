using AutoMapper;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(
            IBookingRepository bookingRepository,
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

            return (_mapper.Map)
        }
    }
}
