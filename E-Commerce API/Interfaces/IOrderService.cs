using E_Commerce_API.Data.Enums;
using E_Commerce_API.Dtos.Order;
using E_Commerce_API.Models.OrderAggregate;

namespace E_Commerce_API.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CancelOrderAsync(int orderId, string customerId);
        Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, string storeOwnerId);
        Task<Order> CreateOrderAsync(CreateOrderRequestDto createOrderDto, string customerId);
    }
}
