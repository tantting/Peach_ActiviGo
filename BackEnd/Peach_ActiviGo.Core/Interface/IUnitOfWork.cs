namespace Peach_ActiviGo.Core.Interface;

public interface IUnitOfWork
{
    ILocationRepository Locations { get; }
    Task <int> SaveChangesAsync(CancellationToken ct);
    
}