namespace Peach_ActiviGo.Services.DTOs.ActivityDtos
{
    public class ActivityRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
