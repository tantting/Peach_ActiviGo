using AutoMapper;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.BookingDtos;

namespace Peach_ActiviGo.Services.Mapping;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        // CreateMap<Source, Destination>();

        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.ActivitySlot.ActivityLocation.Activity.Name))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.ActivitySlot.ActivityLocation.Location.Name))
            .ForMember(dest => dest.IsUpcoming, opt => opt.MapFrom(src => src.ActivitySlot.StartTime > DateTime.Now));
        CreateMap<BookingCreateDto, Booking>();
        CreateMap<BookingUpdateDto, Booking>();
    }
}