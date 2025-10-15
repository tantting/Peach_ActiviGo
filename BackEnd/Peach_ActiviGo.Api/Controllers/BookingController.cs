using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;
using Peach_ActiviGo.Services.Interface;
using System.Security.Claims;

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
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookings(CancellationToken ct)
        {
            var bookings = await _bookingService.GetAllBookingsAsync(ct);
            return Ok(bookings);
        }
        
        // GetAllbyId
        [HttpGet("{id}", Name = "GetBookingById")]
        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]
        public async Task<ActionResult<Booking>> GetBookingById(int id, CancellationToken ct)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id, ct);
            if (booking == null)
            {
                return NotFound(new { errorMessage = "Booking not found!" });
            }   
            return Ok(booking);
        }

        // GetAll By MemberId and status

        // CreateBooking
        [Authorize (Roles = "Member")]
        [HttpPost(Name = "CreateBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult> CreateBooking([FromBody] BookingCreateDto bookingCreateDto, CancellationToken ct)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User not authorized." });
            }

            
            await _bookingService.AddBookingAsync(bookingCreateDto, userId, ct);
            return CreatedAtRoute("GetAllBookings", null);
        }

        // Update (Avbokad för Cut-off)

        // Delete

    }
}
