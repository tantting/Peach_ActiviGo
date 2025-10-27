using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IActivityLocationService
    {
        Task<bool> UpdateActivityLocationStatusAsync(UpdateActivityLocationDto dto, CancellationToken ct);
        Task<IEnumerable<ReadActivityLocationDto>> GetAllActivityLocationsAsync(CancellationToken ct);
        Task<ReadActivityLocationDto> CreateActivityLocationAsync(CreateActivityLocationDto dto, CancellationToken ct);
        Task<IEnumerable<ReadActivityLocationDto>> FilterActivityLocationsAsync(ActivityLocationFilterDto filter, CancellationToken ct);
    }
}
