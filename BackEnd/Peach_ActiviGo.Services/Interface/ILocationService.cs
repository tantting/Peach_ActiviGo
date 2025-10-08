using Peach_ActiviGo.Services.DTOs.LocationDto;

namespace Peach_ActiviGo.Services.Interface;

public interface ILocationService
{
    Task<IEnumerable<ReadLocationDto>> GetAllLocationsAsync();
    Task<ReadLocationDto> GetLocationByIdAsync(int id);
    Task<ReadLocationDto> CreateLocationAsync(CreateLocationDto locationDto);
    Task UpdateLocationAsync(int id, UpdateLocationDto locationDto);
    Task DeleteLocationAsync(int id);   
}