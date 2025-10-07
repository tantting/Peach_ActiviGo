using Peach_ActiviGo.Services.DTOs.AuthDtos;

namespace Peach_ActiviGo.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<ReadLoginResponseDto?> LoginAsync(ReadLoginDto dto);
        Task<object?> RegisterUserAsync(CreateUserDto dto);
    }
}
