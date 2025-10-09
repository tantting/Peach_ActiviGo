using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> Login([FromBody] ReadLoginDto dto, IValidator<ReadLoginDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _authService.LoginAsync(dto);
           
            return Ok(result);
        }
       
        [HttpPut("CreateAccount")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto, IValidator<CreateUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _authService.RegisterUserAsync(dto);

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
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto, IValidator<UpdateUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _authService.UpdateUserAsync(dto);
            if (result == null)
            {
                return BadRequest("Current password is incorrect or user not found.");
            }

            //if (result is IEnumerable<IdentityError> errors)
            //{
            //    return BadRequest(errors);
            //}

            return Ok(result);
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto dto, IValidator<DeleteUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _authService.DeleteUserAsync(dto);

            return Ok("Account deleted successfully.");
        }

        [Authorize]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto, IValidator<RefreshTokenDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _authService.RefreshTokenAsync(dto);
            
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
