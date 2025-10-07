using Peach_ActiviGo.Services.DTOs.AuthDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        Task<ReadLoginResponseDto?> IAuthenticationService.LoginAsync(ReadLoginDto dto)
        {
            throw new NotImplementedException();
        }

        Task IAuthenticationService.RegisterUserAsync(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
