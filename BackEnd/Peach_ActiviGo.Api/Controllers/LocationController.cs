using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;
using Peach_ActiviGo.Services.DTOs.LocationDto;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IActivityLocationService _activityLocationService;

        public LocationController(ILocationService locationService, IActivityLocationService activityLocationService)
        {
            _locationService = locationService;
            _activityLocationService = activityLocationService;
        }

        // GET: api/Location
        [HttpGet(Name = "GetAllLocations")]
        public async Task<IActionResult> GetAllLocations(CancellationToken ct)
        {
            var locations = await _locationService.GetAllLocationsAsync(ct);
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id, CancellationToken ct)
        {
            var location = await _locationService.GetLocationByIdAsync(id, ct);
            if (location == null)
            {
                return NotFound(new { errorMessage = "Location not found!" });
            }

            return Ok(location);
        }

        // POST: api/Location
        [HttpPost(Name = "CreateLocation")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto dto, CancellationToken ct, IValidator<CreateLocationDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var createdLocation = await _locationService.CreateLocationAsync(dto, ct);
            return CreatedAtRoute("GetLocationById", new { id = createdLocation.Id}, createdLocation);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}", Name = "DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int id, CancellationToken ct)
        {
            var deletedLocation = await _locationService.DeleteLocationAsync(id, ct);
            if (!deletedLocation)
            {
                return NotFound();
            }

            return Ok("Location deleted successfully");
        }

        //PUT: api/Location/5
        [HttpPut("{id}", Name = "UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] UpdateLocationDto dto, CancellationToken ct,IValidator<UpdateLocationDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedLocation = await _locationService.UpdateLocationAsync(id, dto, ct);
            if (!updatedLocation)
            {
                return NotFound(new { errorMessage = "Location not found!" });
            }
            return Ok("Location updated successfully");
        }

        [HttpPut("UpdateActivityLocation")]
        public async Task<IActionResult> UpdateActivityLocation([FromBody] UpdateActivityLocationDto dto, CancellationToken ct, IValidator<UpdateActivityLocationDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _activityLocationService.UpdateActivityLocationAsync(dto, ct);
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
    }
}