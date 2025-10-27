using FluentValidation;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Validators;

public class CreateActivityLocationDtoValidator : AbstractValidator<CreateActivityLocationDto>
{
    public CreateActivityLocationDtoValidator()
    {
        RuleFor(x => x.ActivityId)
            .GreaterThan(0).WithMessage("ActivityId must be greater than 0.");
        RuleFor(x => x.LocationId)
            .GreaterThan(0).WithMessage("LocationId must be greater than 0.");
    }
}