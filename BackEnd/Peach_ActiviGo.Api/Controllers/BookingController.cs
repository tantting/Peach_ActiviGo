using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        // GetAllbyId
        
        // GetAll By MemberId and status
        
        // CreateBooking
        
        // Update (Avbokad för Cut-off)
        
        // Delete
    }
}
