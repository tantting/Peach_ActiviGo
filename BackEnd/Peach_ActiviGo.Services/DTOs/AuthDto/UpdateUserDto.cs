namespace Peach_ActiviGo.Services.DTOs.AuthDto
{
    public class UpdateUserDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
