using E_Commerce_API.Dtos.Store;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IStoreService
    {
        Task<Store?> AddStoreAsync(CreateStoreRequestDto createStoreDto);
    }
}
