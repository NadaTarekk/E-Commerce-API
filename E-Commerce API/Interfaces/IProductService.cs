using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IProductService
    {
        Task<Product?> UpdateProductAsync(int productId, UpdateProductRequestDto updateProductDto,
            string storeOwnerId);

        Task<Product> AddProductAsync(CreateProductRequestDto productDto,string storeOwnerId);
    }
}
