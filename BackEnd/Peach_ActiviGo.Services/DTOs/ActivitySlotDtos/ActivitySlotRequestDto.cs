namespace Peach_ActiviGo.Services.DTOs
{
    public class ActivitySlotRequestDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ActivityLocationId { get; set; }
        public int SlotCapacity { get; set; }
    }
}
