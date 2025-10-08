using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Infrastructure.Data;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services
{
    public class ActivityService : IActivityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActivityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ActivityResponseDto>> GetAllAsync()
        {
            var activities = await _context.Activities
                .Include(a => a.Category)
                .ToListAsync();

            return _mapper.Map<List<ActivityResponseDto>>(activities);
        }

        public async Task<ActivityResponseDto?> GetByIdAsync(int id)
        {
            var activity = await _context.Activities
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (activity == null)
            {
                return null;
            }

            return _mapper.Map<ActivityResponseDto>(activity);
        }

        public async Task<ActivityResponseDto> CreateAsync(ActivityRequestDto dto)
        {
            var activity = _mapper.Map<Activity>(dto);

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            var responseDto = _mapper.Map<ActivityResponseDto>(activity);
            responseDto.CategoryName = (await _context.Categories.FindAsync(activity.CategoryId))?.Name ?? string.Empty;

            return responseDto;
        }

        public async Task<bool> UpdateAsync(int id, ActivityRequestDto dto)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return false;
            }

            _mapper.Map(dto, activity);
            activity.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return false;
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
