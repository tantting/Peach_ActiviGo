namespace Peach_ActiviGo.Services.DTOs
{
    public class ActivitySlotResponseDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ActivityLocationId { get; set; }
        public bool IsCanselled { get; set; }
    }
}
