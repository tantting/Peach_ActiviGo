namespace Peach_ActiviGo.Services.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Environment { get; set; }
        public DateTime TimeLenght { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CreateActivityDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Environment { get; set; }
        public DateTime TimeLenght { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }

    public class UpdateActivityDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Environment { get; set; }
        public DateTime TimeLenght { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
