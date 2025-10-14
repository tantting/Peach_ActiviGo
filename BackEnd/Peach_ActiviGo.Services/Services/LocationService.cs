using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
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

    public async Task<IEnumerable<ReadLocationDto>> GetAllLocationsAsync(CancellationToken ct)
    {
        var locations = await _unitOfWork.Locations.GetAllLocationsAsync(ct);
        return _mapper.Map<IEnumerable<ReadLocationDto>>(locations);
    }

    public async Task<ReadLocationDto> GetLocationByIdAsync(int id, CancellationToken ct)
    {
        var location = await _unitOfWork.Locations.GetLocationByIdAsync(id, ct);
        return location == null ? null : _mapper.Map<ReadLocationDto>(location);
    }

    public async Task<ReadLocationDto> CreateLocationAsync(CreateLocationDto locationDto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(locationDto.Name) || string.IsNullOrWhiteSpace(locationDto.Address))
        {
            throw new ArgumentException("Location name and address cannot be empty.");
        }

        var newLocation = _mapper.Map<Location>(locationDto);
        _unitOfWork.Locations.AddLocation(newLocation);
        await _unitOfWork.SaveChangesAsync(ct);

        return _mapper.Map<ReadLocationDto>(newLocation);
    }

    public async Task<bool> UpdateLocationAsync(int id, UpdateLocationDto locationDto, CancellationToken ct)
    {
        var existingLocation = await _unitOfWork.Locations.GetLocationByIdAsync(id, ct);
        if (existingLocation == null)
        {
            throw new KeyNotFoundException("Location not found.");
        }
        _mapper.Map(locationDto, existingLocation);
        _unitOfWork.Locations.UpdateLocation(existingLocation);
        await _unitOfWork.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteLocationAsync(int id, CancellationToken ct)
    {
        var locationToDelete = await _unitOfWork.Locations.GetLocationByIdAsync(id, ct);
        if (locationToDelete == null)
        {
            throw new KeyNotFoundException("Location not found.");
        }
        _unitOfWork.Locations.DeleteLocation(locationToDelete);
        await _unitOfWork.SaveChangesAsync(ct);
        return true;
    }
}