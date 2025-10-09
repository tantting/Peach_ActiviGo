using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;

namespace Peach_ActiviGo.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext _context;
    
    public LocationRepository(AppDbContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken ct)
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<Location> GetLocationByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Locations.FindAsync(id, ct);
    }

    public void AddLocation(Location activityLocation)
    {
        _context.Locations.Add(activityLocation);
    }

    public void UpdateLocation(Location activityLocation)
    {
        _context.Locations.Update(activityLocation);
    }

    public void DeleteLocation(Location activityLocation)
    {
        _context.Locations.Remove(activityLocation);
    }
}