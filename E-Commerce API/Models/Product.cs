using System.ComponentModel.DataAnnotations;
using E_Commerce_API.Models.OrderAggregate;

namespace E_Commerce_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        // Each product belongs to one store
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
