using Peach_ActiviGo.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.DTOs.BookingDtos
{
    public class BookingUpdateDto
    {
        public BookingStatus Status { get; set; } = BookingStatus.Cancelled;
    }
}
