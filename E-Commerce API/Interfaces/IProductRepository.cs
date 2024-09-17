using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Models;
using System.Threading.Tasks;

namespace E_Commerce_API.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int id);
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
    }
}
