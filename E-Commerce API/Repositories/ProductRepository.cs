using E_Commerce_API.Data;
using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product == null) return null;   
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
