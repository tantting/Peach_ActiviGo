namespace Peach_ActiviGo.Core.Interface;

public interface IUnitOfWork
{
    Task <int> SaveChangesAsync(CancellationToken ct);
}