using E_Commerce_API.Dtos.Store;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using E_Commerce_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "SuperAdmin")]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] CreateStoreRequestDto createStoreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var storeResponse = await _storeService.AddStoreAsync(createStoreDto);
            if(storeResponse == null) return BadRequest(new {Message="Store Owner Id doesn't exist"});

            return Ok(storeResponse);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStore([FromRoute]int id)
        {
            var store = await _storeService.DeleteStoreAsync(id);
            if (store == null) return NotFound();
            return NoContent();
        }
        
    }
}
