using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Peach_ActiviGo.Services.Auth;
using Peach_ActiviGo.Services.DTOs.AuthDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthenticationService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ReadLoginResponseDto?> LoginAsync(ReadLoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user == null)
            {
                return null;
            }

            // Check if the password matches. if it doesn't, return null.
            // CheckPasswordSignInAsync handles lockout and other security features. 
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            // Get user roles for token generation.
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenService.GenerateJwtToken(user, roles);

            // Return the authentication response with a token.
            return new ReadLoginResponseDto
            {
                Token = token.Token,
            };
        }

        public Task RegisterUserAsync(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }
        
    }
}