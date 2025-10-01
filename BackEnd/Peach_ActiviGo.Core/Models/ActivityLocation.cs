namespace Peach_ActiviGo.Core.Models
{
    public class ActivityLocation
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }
        public int NumFields { get; set; }
        public int CapacityPerField { get; set; }
        public bool IsIndoor { get; set; }

        public Activity Activity { get; set; }
        public Location Location { get; set; }
    }
}