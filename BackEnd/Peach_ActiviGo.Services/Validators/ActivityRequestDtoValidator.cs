using Peach_ActiviGo.Services.DTOs;
using FluentValidation;

namespace Peach_ActiviGo.Services.Validators
{
    public class ActivityRequestDtoValidator : AbstractValidator<ActivityRequestDto>
    {
        public ActivityRequestDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Price).GreaterThanOrEqualTo(0);
            RuleFor(a => a.CategoryId).GreaterThan(0);
        }
    }
}
