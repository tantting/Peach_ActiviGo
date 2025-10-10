using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;

namespace Peach_ActiviGo.Services.Mapping
{
    public class ActivitySlotProfile : Profile
    {
        public ActivitySlotProfile()
        {
            CreateMap<ActivitySlotRequestDto, ActivitySlot>();
            CreateMap<ActivitySlot, ActivitySlotResponseDto>();
        }
    }
}
