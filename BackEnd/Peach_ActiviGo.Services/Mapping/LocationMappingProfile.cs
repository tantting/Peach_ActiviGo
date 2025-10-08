using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.LocationDto;

namespace Peach_ActiviGo.Services.Mapping;

public class LocationMappingProfile : Profile
{
    public LocationMappingProfile()
    {
        // CreateMap<Source, Destination>();
        CreateMap<Location, ReadLocationDto>();
    }
}