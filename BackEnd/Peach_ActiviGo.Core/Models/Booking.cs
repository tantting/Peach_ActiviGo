using Microsoft.AspNet.Identity.EntityFramework;

namespace Peach_ActiviGo.Core.Models
{
    public class Booking : BaseEntity
    {
        public IdentityUser Customer { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int ActivitySlotId { get; set; }
        
        public ActivitySlot ActivitySlot { get; set; }
    }
}
