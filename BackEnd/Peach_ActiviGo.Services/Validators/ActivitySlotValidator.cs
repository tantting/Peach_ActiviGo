using FluentValidation;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Core.Interfaces;

namespace Peach_ActiviGo.Services.Validators
{
    public class ActivitySlotValidator : AbstractValidator<ActivitySlotRequestDto>
    {
        private readonly IActivitySlotRepository _repo;

        public ActivitySlotValidator(IActivitySlotRepository repo)
        {
            _repo = repo;

            RuleFor(x => x.ActivityLocationId)
                .MustAsync(async (id, ct) => await _repo.ActivityLocationExistsAsync(id))
                .WithMessage("ActivityLocation does not exist.");

            RuleFor(x => x.StartTime)
                .Must(IsAlignedToHour)
                .WithMessage("StartTime must be on a whole hour.");

            RuleFor(x => x.EndTime)
                .Must(IsAlignedToHour)
                .WithMessage("EndTime must be on a whole hour.");

            RuleFor(x => x)
                .Must(dto => dto.EndTime > dto.StartTime)
                .WithMessage("EndTime must be after StartTime.");

            RuleFor(x => x)
                .MustAsync(async (dto, ct) =>
                    !(await _repo.AnyOverlapAsync(dto.ActivityLocationId, dto.StartTime, dto.EndTime)))
                .WithMessage("Slot overlaps with an existing slot.");

            RuleFor(x => x)
                .Must(dto => ((dto.EndTime - dto.StartTime).TotalMinutes % 60) == 0)
                .WithMessage("Slot duration must be a whole number of hours.");
        }

        private bool IsAlignedToHour(DateTime dt)
        {
            return dt.Minute == 0 && dt.Second == 0 && dt.Millisecond == 0;
        }
    }
}
