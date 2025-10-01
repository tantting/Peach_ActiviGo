using Microsoft.AspNet.Identity.EntityFramework;

namespace Peach_ActiviGo.Core.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public IdentityUser Customer { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int ActivityLocationId { get; set; }
        public int ActivitySlotId { get; set; }

        public ActivityLocation ActivityLocation { get; set; }
        public ActivitySlot ActivitySlot { get; set; }
    }
}
