using E_Commerce_API.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce_API.Models.OrderAggregate
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int DeliveryMethodId { get; set; }

        [ForeignKey("DeliveryMethodId")]
        public DeliveryMethod DeliveryMethod { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public AppUser Customer { get; set; }
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        public Address ShipToAddress { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        //[JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}
