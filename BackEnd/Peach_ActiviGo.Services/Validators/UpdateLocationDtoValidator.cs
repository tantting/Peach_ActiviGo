using System.Data;
using FluentValidation;
using Peach_ActiviGo.Services.DTOs.LocationDto;
namespace Peach_ActiviGo.Services.Validators;

public class UpdateLocationDtoValidator : AbstractValidator<UpdateLocationDto>
{
    public UpdateLocationDtoValidator() 
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Latitude)
            .NotNull()
            .InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude)
            .NotNull()
            .InclusiveBetween(-180, 180);
    }
}