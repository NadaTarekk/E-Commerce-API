using System.Text.Json.Serialization;

namespace E_Commerce_API.Models.OrderAggregate
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

        public int Quantity { get; set; }

    }
}
