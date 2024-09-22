using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Services;
using EcommerceAPI.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (success, user, errorMessage) = await _authService.LoginAsync(loginDto);

            if (!success) return Unauthorized(new { Message = errorMessage });

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, newUser, errorMessage) = await _authService.RegisterAsync(registerDto);

            if (!success)
                return BadRequest(new { Message = errorMessage });

            return Ok(newUser);
        }

    }
} 

