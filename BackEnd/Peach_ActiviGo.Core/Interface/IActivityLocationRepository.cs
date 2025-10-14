using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Core.Interface
{
    public interface IActivityLocationRepository
    {
        Task<ActivityLocation> GetActivityLocationByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<ActivityLocation>> GetAllActivityLocationsAsync(CancellationToken ct);
    }
}
