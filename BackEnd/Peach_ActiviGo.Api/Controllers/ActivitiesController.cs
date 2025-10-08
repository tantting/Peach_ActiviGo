using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // Get all activities
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(activities);
        }

        // Get activity by ID
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityRequestDto dto)
        {
            var created = await _activityService.CreateAsync(dto);
            return Ok(created);
        }

        // Update existing activity
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
