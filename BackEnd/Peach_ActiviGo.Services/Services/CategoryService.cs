using AutoMapper;
using FluentValidation;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.CategoryDtos;
using Peach_ActiviGo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryCreateDto> _createValidator;
        private readonly IValidator<CategoryUpdateDto> _updateValidator;

        public CategoryService(
        ICategoryRepository repo, IUnitOfWork uow, IMapper mapper,
        IValidator<CategoryCreateDto> createValidator,
        IValidator<CategoryUpdateDto> updateValidator)
        {
            _repo = repo; _uow = uow; _mapper = mapper;
            _createValidator = createValidator; _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken ct = default)
            => (await _repo.GetAllCategoriesAsync(ct)).Select(_mapper.Map<CategoryDto>);

        public async Task<CategoryDto?> GetByIdAsync(int id, CancellationToken ct = default)
            => (await _repo.GetCategoryByIdAsync(id, ct)) is { } e ? _mapper.Map<CategoryDto>(e) : null;

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto dto, CancellationToken ct = default)
        {
            await _createValidator.ValidateAndThrowAsync(dto, ct);
            if (await _repo.ExistsByNameAsync(dto.Name, null, ct))
                throw new InvalidOperationException($"Kategorin '{dto.Name}' finns redan.");

            var entity = _mapper.Map<Category>(dto);
            await _repo.AddCategoryAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<CategoryDto?> UpdateAsync(int id, CategoryUpdateDto dto, CancellationToken ct = default)
        {
            await _updateValidator.ValidateAndThrowAsync(dto, ct);
            var entity = await _repo.GetCategoryByIdAsync(id, ct);
            if (entity is null) return null;

            if (await _repo.ExistsByNameAsync(dto.Name, id, ct))
                throw new InvalidOperationException($"Kategorin '{dto.Name}' finns redan.");

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.UpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);

            await _repo.UpdateCategoryAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _repo.GetCategoryByIdAsync(id, ct);
            if (entity is null) return false;

            if (await _repo.HasActivitiesAsync(id, ct))
                throw new InvalidOperationException("Kan inte radera kategori som har kopplade aktiviteter.");

            await _repo.DeleteCategoryAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}
