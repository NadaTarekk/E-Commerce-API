using E_Commerce_API.Models.OrderAggregate;

namespace E_Commerce_API.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int id);
        Task UpdateOrderAsync(Order order);
    }
}
