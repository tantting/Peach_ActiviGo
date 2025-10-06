using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityDto>> GetAllActivitiesAsync()
        {
            var activities = await _activityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActivityDto>>(activities);
        }

        public async Task<ActivityDto?> GetActivityByIdAsync(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            return activity == null ? null : _mapper.Map<ActivityDto>(activity);
        }

        public async Task<ActivityDto> CreateActivityAsync(CreateActivityDto createDto)
        {
            var activity = _mapper.Map<Activity>(createDto);
            var createdActivity = await _activityRepository.CreateAsync(activity);
            
            // Reload to get the category information
            var activityWithCategory = await _activityRepository.GetByIdAsync(createdActivity.Id);
            return _mapper.Map<ActivityDto>(activityWithCategory);
        }

        public async Task<ActivityDto> UpdateActivityAsync(int id, UpdateActivityDto updateDto)
        {
            var existingActivity = await _activityRepository.GetByIdAsync(id);
            if (existingActivity == null)
            {
                throw new KeyNotFoundException($"Activity with id {id} not found");
            }

            _mapper.Map(updateDto, existingActivity);
            var updatedActivity = await _activityRepository.UpdateAsync(existingActivity);
            
            // Reload to get the category information
            var activityWithCategory = await _activityRepository.GetByIdAsync(updatedActivity.Id);
            return _mapper.Map<ActivityDto>(activityWithCategory);
        }

        public async Task<bool> DeleteActivityAsync(int id)
        {
            return await _activityRepository.DeleteAsync(id);
        }
    }
}
