using Peach_ActiviGo.Services.DTOs.LocationDto;

namespace Peach_ActiviGo.Services.Interface;

public interface ILocationService
{
    Task<IEnumerable<ReadLocationDto>> GetAllLocationsAsync(CancellationToken ct);
    Task<ReadLocationDto> GetLocationByIdAsync(int id, CancellationToken ct);
    Task<ReadLocationDto> CreateLocationAsync(CreateLocationDto locationDto, CancellationToken ct);
    Task<bool>UpdateLocationAsync(int id, UpdateLocationDto locationDto, CancellationToken ct);
    Task<bool> DeleteLocationAsync(int id, CancellationToken ct = default);   
}