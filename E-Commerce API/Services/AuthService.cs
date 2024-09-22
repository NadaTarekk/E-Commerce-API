using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using EcommerceAPI.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<(bool Success, LoggedInUserDto? User, string? ErrorMessage)> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
                return (false, null, "User Name doesn't exist");

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
                return (false, null, "Incorrect Password");

            var loggedInUser = new LoggedInUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            };

            return (true, loggedInUser, null);
        }

        public async Task<(bool Success, NewUserDto? User, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto)
        {
            // Check if the email is already in use
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
                return (false, null, "Email is already in use.");

            // Create a new user
            AppUser newUser = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!result.Succeeded)
                return (false, null, string.Join(", ", result.Errors.Select(e => e.Description)));

            var newUserDto = new NewUserDto
            {
                UserName = newUser.UserName,
                Email = newUser.Email
            };

            return (true, newUserDto, null);
        }
    }

}
