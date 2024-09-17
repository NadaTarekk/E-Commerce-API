using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto updateProductDto);
        Task<Product?> DeleteProductAsync(int id);
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
    }
}
