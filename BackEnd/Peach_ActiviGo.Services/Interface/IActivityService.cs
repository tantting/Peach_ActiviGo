using Peach_ActiviGo.Services.DTOs;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDto>> GetAllActivitiesAsync();
        Task<ActivityDto?> GetActivityByIdAsync(int id);
        Task<ActivityDto> CreateActivityAsync(CreateActivityDto createDto);
        Task<ActivityDto> UpdateActivityAsync(int id, UpdateActivityDto updateDto);
        Task<bool> DeleteActivityAsync(int id);
    }
}
