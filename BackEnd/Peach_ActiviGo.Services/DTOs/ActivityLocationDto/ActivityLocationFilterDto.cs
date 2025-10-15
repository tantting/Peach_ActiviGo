namespace Peach_ActiviGo.Services.DTOs.ActivityLocationDto
{
    public class ActivityLocationFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsIndoor { get; set; }
        public int? LocationId { get; set; }
        public bool? OnlyAvailableSlots { get; set; }
    }
}
