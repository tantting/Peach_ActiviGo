using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Filter;
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

        public async Task<IEnumerable<ActivityLocation>> FilterActivityLocations(ActivityLocationFilter filter, CancellationToken ct)
        {
            var query = _context.ActivityLocations
                .Include(al => al.Activity)
                .Include(al => al.Location)
                .AsQueryable();

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(activityLocation => activityLocation.Activity.CategoryId == filter.CategoryId);
            }

            if (filter.IsIndoor.HasValue)
            {
                query = query.Where(activityLocation => activityLocation.IsIndoor == filter.IsIndoor.Value);
            }

            if (filter.LocationId.HasValue)
            {
                query = query.Where(activityLocation => activityLocation.LocationId == filter.LocationId.Value);
            }

            if (filter.OnlyAvailableSlots == true)
            {
                // Hämta alla slots för ActivityLocations
                var slotsQuery = _context.ActivitySlots.AsQueryable();
                if (filter.StartDate.HasValue && filter.EndDate.HasValue)
                {
                    slotsQuery = slotsQuery.Where(slot =>
                        slot.StartTime.Date >= filter.StartDate.Value.Date &&
                        slot.EndTime.Date <= filter.EndDate.Value.Date);
                }

                // Hämta slots från databasen och popular med data ifrån databasen.
                var slots = await slotsQuery
                    .Select(slot => new {
                        slot.Id,
                        slot.ActivityLocationId,
                        slot.ActivityLocation,
                        slot.StartTime,
                        slot.EndTime
                    })
                    .ToListAsync(ct);

                // Hämta bokningsräkning per slot från databasen.
                var bookingsPerSlot = await _context.Bookings
                    .GroupBy(booking => booking.ActivitySlotId)
                    .Select(bookings => new { ActivitySlotId = bookings.Key, Count = bookings.Count() })
                    .ToListAsync(ct);

                // Filtrera slots med lediga platser i minnet
                var availableSlotIds = slots
                    .Where(slot =>
                        slot.ActivityLocation != null &&
                        slot.ActivityLocation.Capacity >
                            (bookingsPerSlot.FirstOrDefault(b => b.ActivitySlotId == slot.Id)?.Count ?? 0))
                    .Select(slot => slot.ActivityLocationId)
                    .Distinct()
                    .ToList();

                // Filtrera ActivityLocations
                query = query.Where(activityLocation => availableSlotIds.Contains(activityLocation.Id));
            }

            return await query.ToListAsync(ct);
        }
    }
}
