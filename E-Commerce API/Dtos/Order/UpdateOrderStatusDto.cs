using E_Commerce_API.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Dtos.Order
{
    public class UpdateOrderStatusDto
    {
        [Required]
        public OrderStatus NewStatus { get; set; }
    }
}
