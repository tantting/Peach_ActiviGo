using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.DTOs.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
    }
}
