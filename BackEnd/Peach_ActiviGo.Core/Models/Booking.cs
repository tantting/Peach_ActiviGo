using Microsoft.AspNetCore.Identity;
using Peach_ActiviGo.Core.Enums;
using System;

namespace Peach_ActiviGo.Core.Models
{
    public class Booking : BaseEntity
    {
        public string CustomerId { get; set; }
        public IdentityUser Customer { get; set; }

        
        public int ActivitySlotId { get; set; }
        public ActivitySlot ActivitySlot { get; set; }
        public int NumberOfParticipants { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Active;
        public DateTime? CancelledAt { get; set; }
        public DateTime BookingDate { get; set; }
    }
}