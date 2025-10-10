using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.ActivityDtos;

namespace Peach_ActiviGo.Services.Mapping
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityRequestDto, Activity>();

            CreateMap<Activity, ActivityResponseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
