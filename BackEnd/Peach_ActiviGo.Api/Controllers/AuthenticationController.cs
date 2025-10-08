using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.AuthDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
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
        public async Task<IActionResult> Login([FromBody] ReadLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
            {
                return Unauthorized();
            }
           
            return Ok(result);
        }
       
        [HttpPut("CreateAccount")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var result = await _authService.RegisterUserAsync(dto);
            if (result == null)
            {
                return BadRequest("User already exists.");
            }
            return Ok("Account Created");
        }

        [Authorize]
        [HttpGet("AuthorizeTest")]
        public IActionResult Test()
        {
            return Ok("Ýou are Authorized!");
        }
    }
}
