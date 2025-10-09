using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityResponseDto>> GetAllAsync()
        {
            var activities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActivityResponseDto>>(activities);
        }

        public async Task<ActivityResponseDto?> GetByIdAsync(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            return activity == null ? null : _mapper.Map<ActivityResponseDto>(activity);
        }

        public async Task<ActivityResponseDto> CreateAsync(ActivityRequestDto dto)
        {
            var activity = _mapper.Map<Activity>(dto);
            await _repository.AddAsync(activity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ActivityResponseDto>(activity);
        }

        public async Task<ActivityResponseDto?> UpdateAsync(int id, ActivityRequestDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ActivityResponseDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null) return false;

            await _repository.DeleteAsync(activity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
