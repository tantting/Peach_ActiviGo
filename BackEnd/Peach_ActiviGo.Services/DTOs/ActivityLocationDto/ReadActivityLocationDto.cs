namespace Peach_ActiviGo.Services.DTOs.ActivityLocationDto
{
    public class ReadActivityLocationDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? ActivityName { get; set; }
        public string? LocationName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
