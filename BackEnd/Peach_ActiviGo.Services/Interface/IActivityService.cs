using Peach_ActiviGo.Services.DTOs.ActivityDtos;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivityService
    {
        Task<List<ActivityResponseDto>> GetAllAsync();
        Task<ActivityResponseDto?> GetByIdAsync(int id);
        Task<ActivityResponseDto> CreateAsync(ActivityRequestDto dto);
        Task<bool> UpdateAsync(int id, ActivityRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
