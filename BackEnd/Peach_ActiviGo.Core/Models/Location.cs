namespace Peach_ActiviGo.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LatLong { get; set; }
        public bool IsActive { get; set; }
        public List<ActivityLocation> ActivityLocations { get; set; }
    }
}