using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
