using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.LocationDto;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Location
        [HttpGet(Name = "GetAllLocations")]
        public async Task<IActionResult> GetAllLocations(CancellationToken ct = default)
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id, CancellationToken ct = default)
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
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto dto, CancellationToken ct = default)
        { 
            
            var createdLocation = await _locationService.CreateLocationAsync(dto, ct);
            return CreatedAtRoute("GetLocationById", new { id = createdLocation.Id}, createdLocation);
        }   

        // DELETE: api/Location/5
        [HttpDelete("{id}", Name = "DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int id, CancellationToken ct = default)
        {
            var deletedLocation = await _locationService.DeleteLocationAsync(id, ct);
            if (!deletedLocation)
            {
                return NotFound();
            }

            return Ok("Activity deleted successfully");
        }

        //PUT: api/Location/5

        [HttpPut("{id}", Name = "UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] UpdateLocationDto dto)
        {
            var updatedLocation = await _locationService.UpdateLocationAsync(id, dto);
            if (!updatedLocation)
            {
                return NotFound(new { errorMessage = "Location not found!" });
            }
            return Ok("Location updated successfully");
        }
    }
}
