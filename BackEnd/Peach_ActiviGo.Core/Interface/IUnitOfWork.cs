namespace Peach_ActiviGo.Core.Interface;

public interface IUnitOfWork
{
    ILocationRepository Locations { get; }
    IBookingRepository Bookings { get; }
    IActivityLocationRepository ActivityLocations { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}