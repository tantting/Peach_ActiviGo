using Peach_ActiviGo.Services.DTOs.LocationDto;

namespace Peach_ActiviGo.Services.Interface;

public interface ILocationService
{
    Task<IEnumerable<ReadLocationDto>> GetAllLocationsAsync(CancellationToken ct = default);
    Task<ReadLocationDto> GetLocationByIdAsync(int id, CancellationToken ct = default);
    Task<ReadLocationDto> CreateLocationAsync(CreateLocationDto locationDto, CancellationToken ct = default);
    Task<bool>UpdateLocationAsync(int id, UpdateLocationDto locationDto, CancellationToken ct = default);
    Task<bool> DeleteLocationAsync(int id, CancellationToken ct = default);   
}