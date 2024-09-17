using E_Commerce_API.Dtos.Store;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly UserManager<AppUser> _userManager;

        public StoreService(UserManager<AppUser> userManager,IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            _userManager = userManager;

        }
        public async Task<Store?> AddStoreAsync(CreateStoreRequestDto createStoreDto)
        {
            var stowerOwner = await _userManager.FindByIdAsync(createStoreDto.StoreOwnerId);
            if (stowerOwner == null) return null;

            Store store = new Store
            {
                Name = createStoreDto.Name,
                StoreOwnerId = createStoreDto.StoreOwnerId

            };

            await _storeRepository.AddStoreAsync(store);
            return store;
        }
    }
}
