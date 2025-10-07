using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.AuthDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ReadLoginResponseDto?> Login([FromBody] ReadLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            return result;
        }

        [HttpPut("CreateAccount")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            await _authService.RegisterUserAsync(dto);
            return Ok("Account Created");
        }
    }
}
