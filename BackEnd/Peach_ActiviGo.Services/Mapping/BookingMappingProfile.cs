using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;

namespace Peach_ActiviGo.Services.Mapping;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        // CreateMap<Source, Destination>();

        //CreateMap<Booking, BookingDto>()
        //    .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.ActivitySlot.ActivityLocation.Activity.Name))
        //    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.ActivitySlot.ActivityLocation.Location.Name))
        //    .ForMember(dest => dest.IsUpcoming, opt => opt.MapFrom(src => src.ActivitySlot.StartTime > DateTime.Now));
        //CreateMap<BookingCreateDto, Booking>();
        //CreateMap<BookingUpdateDto, Booking>();

        CreateMap<Booking, BookingDto>()
            .ForMember(d => d.Activity, o => o.MapFrom(s => s.ActivitySlot.ActivityLocation.Activity.Name))
            .ForMember(d => d.Location, o => o.MapFrom(s => s.ActivitySlot.ActivityLocation.Location.Name))
            .ForMember(d => d.StartTime, o => o.MapFrom(s => s.ActivitySlot.StartTime))
            .ForMember(d => d.EndTime, o => o.MapFrom(s => s.ActivitySlot.EndTime))
            .ForMember(d => d.IsUpcoming, o => o.MapFrom(s => s.ActivitySlot.StartTime >= DateTime.UtcNow));
    }
}