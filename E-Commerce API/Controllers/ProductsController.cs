using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "StoreOwner")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description,
                StoreId = productDto.StoreId
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
            
            return Ok(productResponse);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateProductDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = await _productRepository.UpdateProductAsync(id, updateProductDto);

            if (product == null) return NotFound();

            var productResponse = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                StoreId = product.StoreId

            };

            return Ok(productResponse);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var product = await _productRepository.DeleteProductAsync(id);
            if(product == null) return NotFound();
            return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);

        }
    }
}




