using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Mapping
{
    public class ActivityLocationMappingProfile : Profile
    {
        public ActivityLocationMappingProfile()
        {
            // Mapping Model -> DTO
            CreateMap<ActivityLocation, ReadActivityLocationDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<ActivityLocation, UpdateActivityLocationDto>();

            // Mapping DTO -> Model
            CreateMap<ReadActivityLocationDto, ActivityLocation>();
            CreateMap<UpdateActivityLocationDto, ActivityLocation>();
        }
    }
}
