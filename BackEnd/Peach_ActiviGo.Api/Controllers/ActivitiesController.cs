using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.ActivityDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // Get all activities
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(activities);
        }

        // Get activity by ID
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // Create new activity
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityRequestDto dto)
        {
            var created = await _activityService.CreateAsync(dto);
            return Ok(created);
        }

        // Update existing activity
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActivityRequestDto dto)
        {
            var updated = await _activityService.UpdateAsync(id, dto);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok("Activity updated successfully");
        }

        // Delete activity
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _activityService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok("Activity deleted successfully");
        }
    }
}
