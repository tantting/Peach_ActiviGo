using FluentValidation;
using Peach_ActiviGo.Core.Interfaces;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.Services
{
    public class ActivitySlotService : IActivitySlotService
    {
        private readonly IActivitySlotRepository _repo;
        private readonly IValidator<ActivitySlotRequestDto> _validator;

        public ActivitySlotService(IActivitySlotRepository repo, IValidator<ActivitySlotRequestDto> validator)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task<IEnumerable<ActivitySlot>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ActivitySlot?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<ActivitySlot> CreateAsync(ActivitySlotRequestDto dto)
        {
            await _validator.ValidateAndThrowAsync(dto);

            var slot = new ActivitySlot
            {
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ActivityLocationId = dto.ActivityLocationId,
                IsCancelled = false
            };

            await _repo.AddAsync(slot);
            await _repo.SaveChangesAsync();

            return slot;
        }

        public async Task<ActivitySlot?> UpdateAsync(int id, ActivitySlotRequestDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            await _validator.ValidateAndThrowAsync(dto);

            existing.StartTime = dto.StartTime;
            existing.EndTime = dto.EndTime;
            existing.ActivityLocationId = dto.ActivityLocationId;

            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                return false;
            }

            existing.IsCancelled = true;

            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();

            return true;
        }
        // public int GetRemainingCapacity(dto.ActivitySlotId)
        // {
        //     return 
        // }
    }
}
