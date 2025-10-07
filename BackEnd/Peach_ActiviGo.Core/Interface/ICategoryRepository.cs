using Peach_ActiviGo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Core.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default);
        Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct = default);
        Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default);
        Task<bool> HasActivitiesAsync(int categoryId, CancellationToken ct = default);
        Task AddCategoryAsync(Category entity, CancellationToken ct = default);
        Task UpdateCategoryAsync(Category entity, CancellationToken ct = default);
        Task DeleteCategoryAsync(Category entity, CancellationToken ct = default);
    }
}
