using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;

namespace Peach_ActiviGo.Services.Mapping
{
    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            // Activity -> ActivityDto
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // CreateActivityDto -> Activity
            CreateMap<CreateActivityDto, Activity>();

            // UpdateActivityDto -> Activity
            CreateMap<UpdateActivityDto, Activity>();
        }
    }
}
