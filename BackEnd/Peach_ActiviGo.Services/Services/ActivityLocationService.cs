using AutoMapper;
using Peach_ActiviGo.Core.Interface;
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
    }
}
