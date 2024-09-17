using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Dtos.Order
{
    public interface OrderResponseDto
    {
        public int Id { get; set; }
        public int DeliveryMethodId { get; set; }

       
        public string CustomerId { get; set; }

       
        public int StoreId { get; set; }

       
        public AddressDto ShipToAddress { get; set; }

      
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
