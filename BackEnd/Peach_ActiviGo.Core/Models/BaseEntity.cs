namespace Peach_ActiviGo.Core.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;  
    public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? UpdatedDate { get; set; } 
}