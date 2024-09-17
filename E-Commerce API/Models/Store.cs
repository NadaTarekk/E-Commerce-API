using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce_API.Models.OrderAggregate;
namespace E_Commerce_API.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string StoreOwnerId { get; set; }
        [ForeignKey("StoreOwnerId")]
        public AppUser StoreOwner { get; set; }

        // A store can have many products
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
