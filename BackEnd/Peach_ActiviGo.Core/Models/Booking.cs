using Microsoft.AspNetCore.Identity;
using System;

namespace Peach_ActiviGo.Core.Models
{
    public class Booking : BaseEntity
    {
        public string CustomerId { get; set; }           
        public IdentityUser Customer { get; set; }      

        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int ActivitySlotId { get; set; }
        public ActivitySlot ActivitySlot { get; set; }  
    }
}