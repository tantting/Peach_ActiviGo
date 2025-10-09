namespace Peach_ActiviGo.Services.DTOs.AuthDto
{
    public class UpdateUserDto
    {
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
