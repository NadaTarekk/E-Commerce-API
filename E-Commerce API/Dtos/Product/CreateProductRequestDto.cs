using E_Commerce_API.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Dtos.Product
{
    public class CreateProductRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StoreId { get; set; }

    }
}
