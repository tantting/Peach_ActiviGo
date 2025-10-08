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
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound(new { errorMessage = "Location not found!" });
            }

            return Ok(location);
        }
        
        //TEstar
        
        // POST: api/Location
        [HttpPost(Name = "CreateLocation")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto dto)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    errorMessage = "Validation failed.",
                    details = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
        
            var newLocation = dto.ToLocation();
        
            var (success, errorMessage) = await _locationService.CreateLocationAsync(newLocation);
        
            if (!success)
            {
                return BadRequest(new { errorMessage });
            }
        
            var response = newLocation.ToLocationResponse(); 
            return CreatedAtRoute("GetLocationById", new { id = response.Id }, response);
        }   

        // DELETE: api/Location/5
        [HttpDelete("{id}", Name = "DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var existingLocation = await _locationService.GetLocationByIdAsync(id);
            if (existingLocation == null)
            {
                return NotFound(new { errorMessage = "Location not found!" });
            }

            await _locationService.DeleteLocationAsync(id);
            return NoContent();
        }

        // PUT: api/Location/5
        //     [HttpPut("{id}", Name = "UpdateLocation")]
        //     public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] UpdateLocationDto dto)
        //     {
        //         if (!ModelState.IsValid)
        //         {
        //             return BadRequest(new
        //             {
        //                 errorMessage = "Validation failed.",
        //                 details = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
        //             });
        //         }
        //
        //         if (id <= 0)
        //         {
        //             return BadRequest(new { errorMessage = "Invalid location ID" });
        //         }
        //
        //         var locationToUpdate = await _locationService.GetLocationByIdAsync(id);
        //         if (locationToUpdate == null)
        //         {
        //             return NotFound(new { errorMessage = "Location not found!" });
        //         }
        //
        //         locationToUpdate.Name = dto.Name;
        //         locationToUpdate.Address = dto.Address;
        //         locationToUpdate.City = dto.City;
        //         locationToUpdate.State = dto.State;
        //         locationToUpdate.ZipCode = dto.ZipCode;
        //         locationToUpdate.Country = dto.Country;
        //         var (success, errorMessage) = await _locationService.UpdateLocationAsync(locationToUpdate);
        //         if (!success)
        //         {
        //             return BadRequest(new { errorMessage });
        //         }
        //
        //         return NoContent();
        //     }
        // }
    }
}
