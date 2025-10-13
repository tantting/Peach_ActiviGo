using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivityLocationService
    {
        Task<bool> UpdateActivityLocationAsync(UpdateActivityLocationDto dto, CancellationToken ct);
        Task<IEnumerable<ReadActivityLocationDto>> GetAllActivityLocationsAsync(CancellationToken ct);
    }
}
