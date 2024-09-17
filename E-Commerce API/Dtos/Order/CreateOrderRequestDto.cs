using E_Commerce_API.Data.Enums;
using E_Commerce_API.Models;
using E_Commerce_API.Models.OrderAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_API.Dtos.Order
{
    public class CreateOrderRequestDto
    {
        [Required]
        public int DeliveryMethodId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public AddressDto ShipToAddress { get; set; }

        [Required]
        public List<OrderItemDto> OrderItems { get; set; }

    }
}
