using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Dtos.Order
{
    public class OrderItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
