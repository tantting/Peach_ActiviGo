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

            // Returns activity locations that have at least one slot overlapping the date range.
            if (filter.StartDate.HasValue && filter.EndDate.HasValue)
            {
                var start = filter.StartDate.Value.Date;
                var end = filter.EndDate.Value.Date;

                query = query.Where(activityLocation => _context.ActivitySlots.Any(slot =>
                    slot.ActivityLocationId == activityLocation.Id &&
                    !slot.IsCancelled &&
                    slot.EndTime.Date >= start &&
                    slot.StartTime.Date <= end));
            }

            if (filter.OnlyAvailableSlots == true)
            {
                // Consider slots that are not cancelled and (if date range provided) overlap the range.
                var slotsQuery = _context.ActivitySlots
                    .Where(slot => !slot.IsCancelled)
                    .AsQueryable();

                if (filter.StartDate.HasValue && filter.EndDate.HasValue)
                {
                    var start = filter.StartDate.Value.Date;
                    var end = filter.EndDate.Value.Date;

                    // Use overlap logic so slots that partially overlap the range are considered.
                    slotsQuery = slotsQuery.Where(slot =>
                        slot.EndTime.Date >= start &&
                        slot.StartTime.Date <= end);
                }

                // project capacity along with slot so we can determine availability without extra DB lookups
                var slots = await slotsQuery
                    .Select(slot => new {
                        slot.Id,
                        slot.ActivityLocationId,
                        ActivityLocationCapacity = slot.ActivityLocation.Capacity
                    })
                    .ToListAsync(ct);

                // count bookings per slot, excluding cancelled bookings
                var bookingsPerSlot = await _context.Bookings
                    .Where(b => b.CancelledAt == null)
                    .GroupBy(booking => booking.ActivitySlotId)
                    .Select(bookings => new { ActivitySlotId = bookings.Key, Count = bookings.Count() })
                    .ToListAsync(ct);

                var availableLocationIds = slots
                    .Where(slot =>
                        slot.ActivityLocationId != 0 &&
                        slot.ActivityLocationCapacity >
                            (bookingsPerSlot.FirstOrDefault(b => b.ActivitySlotId == slot.Id)?.Count ?? 0))
                    .Select(slot => slot.ActivityLocationId)
                    .Distinct()
                    .ToList();

                query = query.Where(activityLocation => availableLocationIds.Contains(activityLocation.Id));
            }

            return await query.ToListAsync(ct);
        }
    }
}
