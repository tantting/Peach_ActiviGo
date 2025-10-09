using Microsoft.AspNetCore.Identity;
using Peach_ActiviGo.Services.Auth;
using Peach_ActiviGo.Services.DTOs.AuthDto;
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

        public async Task<object?> RegisterUserAsync(CreateUserDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return null;
            }

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
            };

            // Create the user with the specified password.
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return result.Errors;
            }

            await _userManager.AddToRoleAsync(user, "User");

            return new { user.Id, user.Email, Message = "Account created successfully." };
        }

        public async Task<object?> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return null;
            }

            // Verify the current password before allowing an update.
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, dto.CurrentPassword, false);
            if (!passwordCheck.Succeeded)
            {
                return null;
            }

            // Update the password if a new password is provided.
            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordChangeResult = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    return passwordChangeResult.Errors;
                }
            }

            // return an object with user.Id, user.Email and a message.
            return new { user.Id, user.Email, Message = "Account updated successfully." };
        }

        public async Task<object?> DeleteUserAsync(DeleteUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return null;
            }

            // Verify the password before allowing deletion.
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!passwordCheck.Succeeded)
            {
                return null;
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) 
            {
                return result.Errors;
            }

            return new { user.Id, user.Email, Message = "Account deleted successfully." };
        }

        public Task<IEnumerable<GetUsersDto>?> GetAllUsersAsync()
        {
            var users = _userManager.Users.Select(u => new GetUsersDto
            {
                Email = u.Email
            });

            return Task.FromResult<IEnumerable<GetUsersDto>?>(users);
        }

        public async Task<ReadLoginResponseDto?> RefreshTokenAsync(RefreshTokenDto dto)
        {
            // Validate the existing token.
            var getToken = _jwtTokenService.GetCurrentToken(dto.Token);
            if (getToken == null)
            {
                return null;
            }

            // Extract the email claim from the token.
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return null;
            }

            // Get user roles for token generation.
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null)
            {
                return null;
            }

            // Generate a new token.
            var newToken = _jwtTokenService.GenerateJwtToken(user, roles);
            if (newToken.Token == getToken)
            {
                return null;
            }

            // Return the new token.
            return new ReadLoginResponseDto
            {
                Token = newToken.Token,
            };
        }
    }
}