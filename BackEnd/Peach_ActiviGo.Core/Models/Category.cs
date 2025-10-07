namespace Peach_ActiviGo.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public List<Activity> Activities { get; set; } = new();
    }
}
