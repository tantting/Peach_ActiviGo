using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Core.Enums;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;
using Peach_ActiviGo.Services.Interface;
using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingController(IBookingService bookingService, UserManager<IdentityUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
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

        [HttpGet("member/{memberId}/status/{status}")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllByMemberIdAndStatus(
        string memberId,
        BookingStatus status,
        CancellationToken ct)
        {
            var result = await _bookingService.GetAllByMemberIdAndStatusAsync(memberId, status, ct);
            return Ok(result);
        }

        // CreateBooking
        //[Authorize (Roles = "Member")]
        [HttpPost(Name = "CreateBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateBooking([FromBody] BookingCreateDto dto, CancellationToken ct, IValidator<BookingCreateDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            //There are multiple NameIdentifier-claims in the token, so we need to get them all and pick the last one
            var nameIdentifierClaims = User.Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value)
                .ToList();

            var userId = nameIdentifierClaims.LastOrDefault();
            
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Ingen NameIdentifier-claim hittades i tokenen.");
            
            var user = await _userManager.FindByIdAsync(userId); 

            if (user == null)
                return BadRequest($"Ingen användare med ID '{userId}' hittades i databasen.");
            
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User not authorized." });
            }
            await _bookingService.AddBookingAsync(dto, userId, ct);
            return CreatedAtRoute("GetAllBookings", null);
        }

        // Avboka före Cut-off)
        [HttpPut("{id:int}", Name = "CancelBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelBooking(int id, CancellationToken ct)
        {
            await _bookingService.CancelBookingBeforeCutOffAsync(id, ct);
            return NoContent();
        }

        
        // DELETE by id
        [HttpDelete("{id:int}", Name = "DeleteBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBooking(int id, CancellationToken ct)
        {
           
            var existing = await _bookingService.GetBookingByIdAsync(id, ct);
            if (existing is null)
                return NotFound(new { errorMessage = "Booking not found!" });

            await _bookingService.DeleteBookingAsync(id, ct);
            return NoContent();
        }

    }
}
