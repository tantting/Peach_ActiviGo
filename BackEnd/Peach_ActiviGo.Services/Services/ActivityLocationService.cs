using AutoMapper;
using Peach_ActiviGo.Core.Filter;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Core.Models;
using Peach_ActiviGo.Services.DTOs.ActivityLocationDto;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services
{
    public class ActivityLocationService : IActivityLocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActivityLocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> UpdateActivityLocationStatusAsync(UpdateActivityLocationDto dto, CancellationToken ct)
        {
            var activityLocation = await _unitOfWork.ActivityLocations.GetActivityLocationByIdAsync(dto.id, ct);

            // If the activity location doesn't exist, return false
            if (activityLocation == null)
            {
                return false;
            }

            _mapper.Map(dto, activityLocation);
            activityLocation.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);

            await _unitOfWork.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<ReadActivityLocationDto>> GetAllActivityLocationsAsync(CancellationToken ct)
        {
            var activityLocations = await _unitOfWork.ActivityLocations.GetAllActivityLocationsAsync(ct);

            return _mapper.Map<IEnumerable<ReadActivityLocationDto>>(activityLocations);
        }
        
        public async Task<ReadActivityLocationDto> CreateActivityLocationAsync(CreateActivityLocationDto dto, CancellationToken ct)
        {
            var activityLocation = _mapper.Map<ActivityLocation>(dto);
            activityLocation.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            activityLocation.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);

            _unitOfWork.ActivityLocations.Add(activityLocation);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<ReadActivityLocationDto>(activityLocation);
        }   

        public async Task<IEnumerable<ReadActivityLocationDto>> FilterActivityLocationsAsync(ActivityLocationFilterDto filter, CancellationToken ct)
        {
            // Map DTO to core filter
            var coreFilter = new ActivityLocationFilter
            {
                StartDate = filter.StartDate,
                EndDate = filter.EndDate,
                CategoryId = filter.CategoryId,
                IsIndoor = filter.IsIndoor,
                LocationId = filter.LocationId,
                OnlyAvailableSlots = filter.OnlyAvailableSlots,
                RequiredPersons = filter.RequiredPersons
            };

            var activityLocations = await _unitOfWork.ActivityLocations
                .FilterActivityLocations(coreFilter, ct);

            return _mapper.Map<IEnumerable<ReadActivityLocationDto>>(activityLocations);
        }
    }
}
