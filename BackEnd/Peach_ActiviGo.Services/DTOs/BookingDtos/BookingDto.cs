using Peach_ActiviGo.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.DTOs.BookingDtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public string? Activity { get; set; }
        public string? Location { get; set; }
        public DateTime BookingDate { get; set; }

        public BookingStatus Status { get; set; }
        public DateTime? CancelledAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsUpcoming { get; set; }
    }
}
