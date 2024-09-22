using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IStoreRepository
    {
        Task AddStoreAsync(Store store);
        Task DeleteStoreAsync(Store store);
        Task<Store?> GetStoreByIdAsync(int id);
        Task<Store?> GetStoreByOwnerId(string ownerId);
    }
}
