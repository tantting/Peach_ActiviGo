using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateOnly CreatedDate { get; init; }
        public DateOnly? UpdatedDate { get; init; }
    }
}
