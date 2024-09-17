using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using EcommerceAPI.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(loginDto.Username);


            if (user == null) return Unauthorized(new { Message = "User Name doen't exist" });

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized(new { Message = "Incorrect Password" });

            return Ok(new LoggedInUserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)

            });


        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null) return BadRequest(new { Message = "Email is already in use." });

            AppUser newUser = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Username

            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(new NewUserDto
            {
                UserName = newUser.UserName,
                Email = newUser.Email
            });

        }
    }
} 

