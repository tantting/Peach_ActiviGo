using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        //GetAll
        [HttpGet(Name = "GetAllBookings")]
        [ProducesResponseType(typeof(IEnumerable<Booking>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
        
        // GetAllbyId
        [HttpGet("{id}", Name = "GetBookingById")]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound(new { errorMessage = "Booking not found!" });
            }   
            return Ok(booking);
        }
        
        // GetAll By MemberId and status
        
        // CreateBooking
        
        // Update (Avbokad för Cut-off)
        
        // Delete
        
    }
}
