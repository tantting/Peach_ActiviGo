namespace Peach_ActiviGo.Core.Models
{
    public class ActivitySlot : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ActivityLocationId { get; set; }
        public bool IsCanselled { get; set; } = false; 

        public ActivityLocation ActivityLocation { get; set; }
    }
}