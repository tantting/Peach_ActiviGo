using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Core.Interfaces
{
    public interface IActivitySlotRepository
    {
        Task<IEnumerable<ActivitySlot>> GetAllAsync();
        Task<ActivitySlot?> GetByIdAsync(int id);
        Task AddAsync(ActivitySlot slot);
        Task UpdateAsync(ActivitySlot slot);
        Task<bool> AnyOverlapAsync(int activityLocationId, DateTime start, DateTime end, int? excludeSlotId = null);
        Task<bool> ActivityLocationExistsAsync(int activityLocationId);
        Task SaveChangesAsync();
    }
}
