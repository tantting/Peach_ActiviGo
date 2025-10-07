using Peach_ActiviGo.Services.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken ct = default);
        Task<CategoryDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<CategoryDto> CreateAsync(CategoryCreateDto dto, CancellationToken ct = default);
        Task<CategoryDto?> UpdateAsync(int id, CategoryUpdateDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
