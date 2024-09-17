using E_Commerce_API.Dtos.Store;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IStoreRepository _storeRepository;

        public StoresController(IStoreRepository storeRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _storeRepository = storeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] CreateStoreRequestDto createStoreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stowerOwner = await _userManager.FindByIdAsync(createStoreDto.StoreOwnerId);
            if (stowerOwner == null) return NotFound(new { Message = "this store owner doesn't exist" });

            Store store = new Store
            {
                Name = createStoreDto.Name,
                StoreOwnerId = createStoreDto.StoreOwnerId

            };

             await _storeRepository.AddStoreAsync(store);

            var storeResponse = new StoreResponseDto
            {
                Name = store.Name,
                Id = store.Id,
                StoreOwnerId =store.StoreOwnerId
            };
            return Ok(storeResponse);

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStore([FromRoute]int id)
        {
            var store = await _storeRepository.DeleteStoreAsync(id);
            if (store == null) return NotFound();
            return NoContent();
        }
        
    }
}
