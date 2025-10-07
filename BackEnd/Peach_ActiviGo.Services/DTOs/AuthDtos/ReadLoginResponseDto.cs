namespace Peach_ActiviGo.Services.DTOs.AuthDtos
{
    public class ReadLoginResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
