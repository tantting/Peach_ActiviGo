using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.AuthDto;
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

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _authService.GetAllUsersAsync();
            if (result == null || !result.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(result);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
        {
            var result = await _authService.UpdateUserAsync(dto);
            if (result == null)
            {
                return BadRequest("User does not exist.");
            }
            
            return Ok("Account Updated");
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto dto)
        {
            var result = await _authService.DeleteUserAsync(dto);

            if (result == null)
            {
                return BadRequest("User does not exist.");
            }

            return Ok("Account deleted successfully.");
        }

        [Authorize]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.RefreshTokenAsync(refreshTokenDto);
            if (result == null)
            {
                return Unauthorized("Invalid token.");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("AuthorizeTest")]
        public IActionResult Test()
        {
            return Ok("Ýou are Authorized!");
        }
    }
}
