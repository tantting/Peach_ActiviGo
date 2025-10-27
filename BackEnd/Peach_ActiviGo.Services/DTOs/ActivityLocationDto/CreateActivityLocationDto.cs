using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Services.DTOs.ActivityLocationDto;

public class CreateActivityLocationDto
{
    public int ActivityId { get; set; }
    public int LocationId { get; set; }
    public bool IsIndoor { get; set; }
    public bool isActive { get; set; } = true;
}