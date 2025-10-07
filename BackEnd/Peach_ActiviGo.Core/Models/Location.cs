namespace Peach_ActiviGo.Core.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string LatLong { get; set; }
        
        public List<ActivityLocation> ActivityLocations { get; set; }
    }
}