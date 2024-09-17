using E_Commerce_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_API.Dtos.Store
{
    public class StoreResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string StoreOwnerId { get; set; }
        
    }
}
