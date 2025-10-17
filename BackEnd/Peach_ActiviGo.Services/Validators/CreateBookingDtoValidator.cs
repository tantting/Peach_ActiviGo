using FluentValidation;
using Peach_ActiviGo.Services.DTOs.BookingDtos;

namespace Peach_ActiviGo.Services.Validators;

public class CreateBookingDtoValidator : AbstractValidator<BookingCreateDto>
{
    public CreateBookingDtoValidator()
    {
        RuleFor(x => x.ActivitySlotId).GreaterThan(0).WithMessage("ActivitySlotId must be greater than 0.");
    }
}