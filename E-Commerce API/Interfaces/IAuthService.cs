using EcommerceAPI.Dtos.User;

namespace E_Commerce_API.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, LoggedInUserDto? User, string? ErrorMessage)> LoginAsync(LoginDto loginDto);
        Task<(bool Success, NewUserDto? User, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto);
    }
}
