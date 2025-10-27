using System.ComponentModel.DataAnnotations;

namespace Peach_ActiviGo.Core.Models
{
    public class ActivitySlot : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ActivityLocationId { get; set; }
        public bool IsCancelled { get; set; } = false; 
        public int SlotCapacity { get; set; }
        public int RemainingCapacity { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ActivityLocation ActivityLocation { get; set; }
    }
}