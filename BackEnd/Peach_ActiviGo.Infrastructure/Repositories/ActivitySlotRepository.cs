using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Interfaces;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;

namespace Peach_ActiviGo.Infrastructure.Repositories
{
    public class ActivitySlotRepository : IActivitySlotRepository
    {
        private readonly AppDbContext _context;

        public ActivitySlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivitySlot>> GetAllAsync()
        {
            return await _context.ActivitySlots
                .Include(s => s.ActivityLocation)
                .OrderBy(s => s.StartTime).ToListAsync();
        }

        public async Task<ActivitySlot?> GetByIdAsync(int id)
        {
            return await _context.ActivitySlots
                .Include(s => s.ActivityLocation)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(ActivitySlot slot)
        {
            await _context.ActivitySlots.AddAsync(slot);
        }

        public async Task UpdateAsync(ActivitySlot slot)
        {
            _context.ActivitySlots.Update(slot);
        }

        public async Task<bool> AnyOverlapAsync(int activityLocationId, DateTime start, DateTime end, int? excludeSlotId = null)
        {
            var query = _context.ActivitySlots.Where(s =>
                s.ActivityLocationId == activityLocationId &&
                !s.IsCancelled &&
                start < s.EndTime &&
                end > s.StartTime);

            if (excludeSlotId.HasValue)
                query = query.Where(s => s.Id != excludeSlotId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ActivityLocationExistsAsync(int activityLocationId)
        {
            return await _context.ActivityLocations.AnyAsync(al => al.Id == activityLocationId && al.isActive);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
