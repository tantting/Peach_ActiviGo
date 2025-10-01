namespace Peach_ActiviGo.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Environment { get; set; }
        public DateTime TimeLenght { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }


        public Category Category { get; set; }
    }
}
