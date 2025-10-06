using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly ILogger<ActivitiesController> _logger;

        public ActivitiesController(IActivityService activityService, ILogger<ActivitiesController> logger)
        {
            _activityService = activityService;
            _logger = logger;
        }

        /// <summary>
        /// Get all activities
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAll()
        {
            try
            {
                var activities = await _activityService.GetAllActivitiesAsync();
                return Ok(activities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all activities");
                return StatusCode(500, "An error occurred while retrieving activities");
            }
        }

        /// <summary>
        /// Get activity by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetById(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityByIdAsync(id);
                if (activity == null)
                {
                    return NotFound($"Activity with id {id} not found");
                }
                return Ok(activity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting activity by id {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the activity");
            }
        }

        /// <summary>
        /// Create a new activity
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ActivityDto>> Create([FromBody] CreateActivityDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdActivity = await _activityService.CreateActivityAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = createdActivity.Id }, createdActivity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating activity");
                return StatusCode(500, "An error occurred while creating the activity");
            }
        }

        /// <summary>
        /// Update an existing activity
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityDto>> Update(int id, [FromBody] UpdateActivityDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedActivity = await _activityService.UpdateActivityAsync(id, updateDto);
                return Ok(updatedActivity);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Activity with id {Id} not found", id);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating activity with id {Id}", id);
                return StatusCode(500, "An error occurred while updating the activity");
            }
        }

        /// <summary>
        /// Delete an activity
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _activityService.DeleteActivityAsync(id);
                if (!result)
                {
                    return NotFound($"Activity with id {id} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting activity with id {Id}", id);
                return StatusCode(500, "An error occurred while deleting the activity");
            }
        }
    }
}
