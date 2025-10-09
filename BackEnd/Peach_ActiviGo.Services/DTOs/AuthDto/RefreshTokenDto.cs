namespace Peach_ActiviGo.Services.DTOs.AuthDto
{
    public class RefreshTokenDto
    {
        public string Email { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
    }
}
