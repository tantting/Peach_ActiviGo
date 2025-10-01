namespace Peach_ActiviGo.Core.Models
{
    public class ActivitySlot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public int ActivityLocationId { get; set; }

        public ActivityLocation ActivityLocation { get; set; }
    }
}