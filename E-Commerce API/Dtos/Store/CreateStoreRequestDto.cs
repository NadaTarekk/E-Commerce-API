using E_Commerce_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_API.Dtos.Store
{
    public class CreateStoreRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string StoreOwnerId { get; set; }

    }
}
