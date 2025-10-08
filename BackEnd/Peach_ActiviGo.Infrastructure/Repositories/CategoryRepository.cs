using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;



namespace Peach_ActiviGo.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Category>> GetAllCategoriesAsync(CancellationToken ct = default) =>
        _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(ct);

        public Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct = default) =>
            _context.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);

        public Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default) =>
            _context.Categories.AnyAsync(
                c => c.Name.ToLower() == name.ToLower()
                  && (!excludeId.HasValue || c.Id != excludeId.Value),
                ct);

        public Task<bool> HasActivitiesAsync(int categoryId, CancellationToken ct = default) =>
            _context.Activities.AnyAsync(a => a.CategoryId == categoryId, ct);

        public Task AddCategoryAsync(Category entity, CancellationToken ct = default) =>
            _context.Categories.AddAsync(entity, ct).AsTask();

        public Task UpdateCategoryAsync(Category entity, CancellationToken ct = default)
        {
            _context.Categories.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteCategoryAsync(Category entity, CancellationToken ct = default)
        {
            _context.Categories.Remove(entity);
            return Task.CompletedTask;
        }
    }
}


