namespace Peach_ActiviGo.Services.DTOs.LocationDto;

public record UpdateLocationDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
}