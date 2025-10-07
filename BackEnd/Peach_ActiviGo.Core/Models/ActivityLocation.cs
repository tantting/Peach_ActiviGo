namespace Peach_ActiviGo.Core.Models
{
    public class ActivityLocation : BaseEntity
    {
        public int ActivityId { get; set; }
        public int LocationId { get; set; }
        public int NumberOfFields { get; set; }
        public int CapacityPerField { get; set; }
        public bool IsIndoor { get; set; }

        public Activity Activity { get; set; }
        public Location Location { get; set; }
    }
}