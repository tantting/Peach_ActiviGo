using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Core.Interface;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocationsAsync();
    Task<Location> GetLocationByIdAsync(int id);
    void AddLocation(Location activityLocation);
    void UpdateLocation(Location activityLocation);
    void DeleteLocation(Location activityLocation);
}