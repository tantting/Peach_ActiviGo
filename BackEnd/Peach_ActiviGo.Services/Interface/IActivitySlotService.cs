using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.DTOs.ActivityDtos;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivitySlotService
    {
        Task<IEnumerable<ActivitySlot>> GetAllAsync();
        Task<ActivitySlot?> GetByIdAsync(int id);
        Task<ActivitySlot> CreateAsync(ActivitySlotRequestDto dto);
        Task<ActivitySlot?> UpdateAsync(int id, ActivitySlotRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
