using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Infrastructure.Data;

namespace Peach_ActiviGo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ILocationRepository _locations;
    private IBookingRepository _bookings;
    private IActivityLocationRepository _activityLocation;


    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ILocationRepository Locations => _locations ??= new LocationRepository(_context);
    public IBookingRepository Bookings => _bookings ??= new BookingRepository(_context);
    public IActivityLocationRepository ActivityLocations => _activityLocation ??= new ActivityLocationRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
}