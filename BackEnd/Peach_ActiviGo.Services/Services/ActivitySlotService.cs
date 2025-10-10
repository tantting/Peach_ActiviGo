using Peach_ActiviGo.Core.Interfaces;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peach_ActiviGo.Services.Services
{
    public class ActivitySlotService : IActivitySlotService
    {
        private readonly IActivitySlotRepository _repo;

        public ActivitySlotService(IActivitySlotRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ActivitySlot>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ActivitySlot?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<ActivitySlot> CreateAsync(ActivitySlot slot)
        {
            if (!await _repo.ActivityLocationExistsAsync(slot.ActivityLocationId))
            {
                throw new ArgumentException($"ActivityLocation {slot.ActivityLocationId} does not exist.");
            }

            if (!IsAlignedToHour(slot.StartTime) || !IsAlignedToHour(slot.EndTime))
            {
                throw new ArgumentException("StartTime and EndTime must be on whole hours.");
            }

            if (slot.EndTime <= slot.StartTime)
            {
                throw new ArgumentException("EndTime must be after StartTime.");
            }

            if ((slot.EndTime - slot.StartTime).TotalMinutes % 60 != 0)
            {
                throw new ArgumentException("Slot duration must be a whole number of hours.");
            }

            if (await _repo.AnyOverlapAsync(slot.ActivityLocationId, slot.StartTime, slot.EndTime))
            {
                throw new InvalidOperationException(message: "Slot overlaps with existing slot.");
            }

            slot.IsCanselled = false;

            await _repo.AddAsync(slot);
            await _repo.SaveChangesAsync();

            return slot;
        }

        public async Task<ActivitySlot?> UpdateAsync(int id, ActivitySlot slot)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                return null;
            }

            if (!await _repo.ActivityLocationExistsAsync(slot.ActivityLocationId))
            {
                throw new ArgumentException($"ActivityLocation {slot.ActivityLocationId} does not exist.");
            }

            if (!IsAlignedToHour(slot.StartTime) || !IsAlignedToHour(slot.EndTime))
            {
                throw new ArgumentException("StartTime and EndTime must be on whole hours.");
            }

            if (slot.EndTime <= slot.StartTime)
            {
                throw new ArgumentException("EndTime must be after StartTime.");
            }

            if ((slot.EndTime - slot.StartTime).TotalMinutes % 60 != 0)
            {
                throw new ArgumentException("Slot duration must be a whole number of hours.");
            }

            if (await _repo.AnyOverlapAsync(slot.ActivityLocationId, slot.StartTime, slot.EndTime, excludeSlotId: id))
            {
                throw new InvalidOperationException("Slot overlaps with existing slot.");
            }

            existing.StartTime = slot.StartTime;
            existing.EndTime = slot.EndTime;
            existing.ActivityLocationId = slot.ActivityLocationId;

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

            existing.IsCanselled = true;

            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();

            return true;
        }

        private static bool IsAlignedToHour(DateTime dt)
        {
            return dt.Minute == 0 && dt.Second == 0 && dt.Millisecond == 0;
        }
    }
}
