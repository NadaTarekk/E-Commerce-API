using E_Commerce_API.Dtos.Product;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using E_Commerce_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "StoreOwner")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var storeOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var productResponse = await _productService.AddProductAsync(productDto, storeOwnerId);
            return Ok(productResponse);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateProductDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var storeOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var productResponse = await _productService.UpdateProductAsync(id, updateProductDto, storeOwnerId);

            if (productResponse == null) return BadRequest(new {
                Message="Product not found or doesn't belong to this store owner"});

            return Ok(productResponse);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var storeOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = await _productService.DeleteProductAsync(id, storeOwnerId);
            if (product == null) return BadRequest(new
            {
                Message = "Product not found or doesn't belong to this store owner"
            });

            return NoContent();

        }

        
    }
}




