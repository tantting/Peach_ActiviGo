using FluentValidation;
using Peach_ActiviGo.Services.DTOs.AuthDto;

namespace Peach_ActiviGo.Services.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);
           RuleFor(x => x.CurrentPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$");
           RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$");
        }
    }
}
