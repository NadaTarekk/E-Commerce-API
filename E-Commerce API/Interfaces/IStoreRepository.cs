using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IStoreRepository
    {
        Task AddStoreAsync(Store store);
        Task<Store?> DeleteStoreAsync(int id);
        Task<Store?> GetStoreByIdAsync(int id);
    }
}
