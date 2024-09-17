using Microsoft.AspNetCore.Identity;
using E_Commerce_API.Models.OrderAggregate;
namespace E_Commerce_API.Models
{
    public class AppUser : IdentityUser
    {
        public List<Order> Orders { get; set; }
    }
}
