using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Core.Filter;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Mapping
{
    public class ActivityLocationMappingProfile : Profile
    {
        public ActivityLocationMappingProfile()
        {
            // Model -> DTO
            CreateMap<ActivityLocation, ReadActivityLocationDto>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.Name))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Activity.ImageUrl))
                .ForMember(dest => dest.IsIndoor, opt => opt.MapFrom(src => src.IsIndoor))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude));


            CreateMap<ActivityLocation, UpdateActivityLocationDto>();

            // DTO -> Model
            CreateMap<ReadActivityLocationDto, ActivityLocation>();
            CreateMap<UpdateActivityLocationDto, ActivityLocation>();
            CreateMap<CreateActivityLocationDto, ActivityLocation>();

            // Filter DTO -> Filter Model
            CreateMap<ActivityLocationFilterDto, ActivityLocationFilter>();
        }
    }
}
