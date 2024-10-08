﻿using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public ProductService(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            _productRepository = productRepository;
            _storeRepository = storeRepository;
        }

        public async  Task<ProductResponseDto> AddProductAsync(CreateProductRequestDto productDto, string storeOwnerId)
        {
            var store = await _storeRepository.GetStoreByOwnerId(storeOwnerId);

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description,
                StoreId = store.Id
            };

            await _productRepository.AddProductAsync(product);
            var productResponse = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                StoreId = product.StoreId

            };
            return productResponse;
        }

        public async Task<Product?> DeleteProductAsync(int productId, string storeOwnerId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null) return null;
            var store = await _storeRepository.GetStoreByOwnerId(storeOwnerId);
            if (product.StoreId != store.Id) return null;
            var deletedProduct = await _productRepository.DeleteProductAsync(product);
            return deletedProduct;
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(int productId, UpdateProductRequestDto updateProductDto, string storeOwnerId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null) return null;
            var store = await _storeRepository.GetStoreByOwnerId(storeOwnerId);
            if (product.StoreId != store.Id) return null;

            product.Price = updateProductDto.Price;
            product.Description = updateProductDto.Description;
            product.Name = updateProductDto.Name;
            product.Stock = updateProductDto.Stock;

            var newProduct = await _productRepository.UpdateProductAsync(product);

            var productResponse = new ProductResponseDto
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Stock = newProduct.Stock,
                Description = newProduct.Description,
                StoreId = newProduct.StoreId

            };

            return productResponse;
        }

    }
}
