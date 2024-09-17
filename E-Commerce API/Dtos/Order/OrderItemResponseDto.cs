using System.Text.Json.Serialization;

namespace E_Commerce_API.Dtos.Order
{
    public interface OrderItemResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
