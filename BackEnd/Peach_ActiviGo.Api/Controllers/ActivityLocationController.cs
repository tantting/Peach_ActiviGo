using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    //[Authorize( Roles = "AdminOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLocationController : ControllerBase
    {
        private readonly IActivityLocationService _activityLocationService;
        public ActivityLocationController(IActivityLocationService activityLocationService)
        {
            _activityLocationService = activityLocationService;
        }

        [HttpPut("UpdateActivityLocationStatus")]
        public async Task<IActionResult> UpdateActivityStatusLocation([FromBody] UpdateActivityLocationDto dto, CancellationToken ct, IValidator<UpdateActivityLocationDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _activityLocationService.UpdateActivityLocationStatusAsync(dto, ct);
            if (!result)
            {
                return NotFound(new { errorMessage = $"No ActivityLocation found with Id {dto.id}" });
            }

            return Ok(new { message = $"ActivityLocation {(dto.IsActive ? "activated" : "deactivated")} successfully." });
        }

        [HttpGet("GetAllActivityLocations")]
        public async Task<IActionResult> GetAllActivityLocations(CancellationToken ct)
        {
            var locations = await _activityLocationService.GetAllActivityLocationsAsync(ct);

            return Ok(locations);
        }

        [HttpPost("FilterActivityLocations")]
        public async Task<IActionResult> FilterActivityLocations([FromBody] ActivityLocationFilterDto filter, CancellationToken ct)
        {
            var result = await _activityLocationService.FilterActivityLocationsAsync(filter, ct);
            return Ok(result);
        }
    }
}
