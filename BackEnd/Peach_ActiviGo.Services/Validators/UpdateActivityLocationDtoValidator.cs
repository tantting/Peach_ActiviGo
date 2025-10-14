using FluentValidation;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

namespace Peach_ActiviGo.Services.Validators
{
    public class UpdateActivityLocationDtoValidator : AbstractValidator<UpdateActivityLocationDto>
    {
        public UpdateActivityLocationDtoValidator()
        {
            RuleFor(x => x.id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive must not be null.");
        }
    }
}
