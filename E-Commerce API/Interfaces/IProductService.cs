using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Models;

namespace E_Commerce_API.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDto?> UpdateProductAsync(int productId, UpdateProductRequestDto updateProductDto,
            string storeOwnerId);
        Task<ProductResponseDto> AddProductAsync(CreateProductRequestDto productDto,string storeOwnerId);

        Task<Product?> DeleteProductAsync(int productId, string storeOwnerId);
    }
}
