using E_Commerce_API.Data;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteStoreAsync(Store store)
        {
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            return await _context.Stores.FirstOrDefaultAsync(s => s.Id == id); 
        }

        public async Task<Store?> GetStoreByOwnerId(string ownerId)
        {
            return await _context.Stores.FirstOrDefaultAsync(s => s.StoreOwnerId == ownerId);
        }
    }
}
