using E_Commerce_API.Dtos.Store;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IStoreService
    {
        Task<StoreResponseDto?> AddStoreAsync(CreateStoreRequestDto createStoreDto);
        Task<Store?> DeleteStoreAsync(int id);
    }
}
