using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;

namespace Peach_ActiviGo.Infrastructure.Repositories
{
    public class ActivityLocationRepository : IActivityLocationRepository
    {
        private readonly AppDbContext _context;
        public ActivityLocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActivityLocation?> GetActivityLocationByIdAsync(int id, CancellationToken ct)
        {
            return await _context.ActivityLocations.FirstOrDefaultAsync(activityLocation => activityLocation.Id == id, ct);
        }
        
        public async Task<IEnumerable<ActivityLocation>> GetAllActivityLocationsAsync(CancellationToken ct)
        {
            return await _context.ActivityLocations
                .Include(activityLocation => activityLocation.Activity)
                .Include(activityLocation => activityLocation.Location)
                .ToListAsync(ct);
        }
    }
}
