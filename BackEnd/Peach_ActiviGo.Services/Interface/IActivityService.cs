using Peach_ActiviGo.Services.DTOs;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityResponseDto>> GetAllAsync();
        Task<ActivityResponseDto?> GetByIdAsync(int id);
        Task<ActivityResponseDto> CreateAsync(ActivityRequestDto dto);
        Task<ActivityResponseDto?> UpdateAsync(int id, ActivityRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
