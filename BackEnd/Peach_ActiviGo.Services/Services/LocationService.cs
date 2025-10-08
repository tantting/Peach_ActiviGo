using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Services.DTOs.LocationDto;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services;

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Task<IEnumerable<ReadLocationDto>> GetAllLocationsAsync()
    {
        var locations = _unitOfWork.Locations.GetAllLocationsAsync();
        // Map locations to ReadLocationDto
    }

    public Task<ReadLocationDto> GetLocationByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ReadLocationDto> CreateLocationAsync(CreateLocationDto locationDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLocationAsync(int id, UpdateLocationDto locationDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLocationAsync(int id)
    {
        throw new NotImplementedException();
    }
}