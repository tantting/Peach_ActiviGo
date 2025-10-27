using FluentValidation;
using Peach_ActiviGo.Services.DTOs.BookingDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Validators;

public class CreateBookingDtoValidator : AbstractValidator<BookingCreateDto>
{
    public CreateBookingDtoValidator()
    {
        RuleFor(x => x.ActivitySlotId).GreaterThan(0).WithMessage("ActivitySlotId must be greater than 0.");
        RuleFor(x => x.NumberOfParticipants).GreaterThan(0).WithMessage("NumberOfParticipants must be greater than 0."); 
    }
}