namespace Peach_ActiviGo.Core.Models
{
    public class ActivityLocation : BaseEntity
    {
        public int ActivityId { get; set; }
        public int LocationId { get; set; }
        public int Capacity { get; set; }
        public bool IsIndoor { get; set; }
        public bool isActive { get; set; } = true;

        public Activity Activity { get; set; }
        public Location Location { get; set; }
    }
}