using Peach_ActiviGo.Core.Interfaces;

namespace Peach_ActiviGo.Core.Interface;

public interface IUnitOfWork
{
    ILocationRepository Locations { get; }
    IBookingRepository Bookings { get; }
    IActivityLocationRepository ActivityLocations { get; }
    IActivitySlotRepository ActivitySlots { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}