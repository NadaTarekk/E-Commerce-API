using E_Commerce_API.Data;
using E_Commerce_API.Data.Enums;
using E_Commerce_API.Dtos.Order;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models.OrderAggregate;
using E_Commerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository, IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
             _orderRepository = orderRepository;
        }

        public async Task<bool> CancelOrderAsync(int orderId, string customerId)
        {

            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null || order.CustomerId != customerId)
            {
                return false; // Order not found or user is not authorized
            }

            
            if (order.Status == OrderStatus.Cancelled || order.Status == OrderStatus.Completed)
            {
                return false;
            }

            order.Status = OrderStatus.Cancelled;

            await _orderRepository.UpdateOrderAsync(order);

            return true;
        }

            public async Task<Order> CreateOrderAsync(CreateOrderRequestDto createOrderDto, string customerId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var orderitem in createOrderDto.OrderItems)
            {
                orderItems.Add(new OrderItem
                {
                    ProductId = orderitem.ProductId,
                    Quantity = orderitem.Quantity,

                });
            }

            var order = new Order
            {
                DeliveryMethodId = createOrderDto.DeliveryMethodId,
                CustomerId = customerId,
                StoreId = createOrderDto.StoreId,
                ShipToAddress = createOrderDto.ShipToAddress,
                OrderItems = orderItems

            };

            await _orderRepository.AddOrderAsync(order);
            return order;

        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, string storeOwnerId)
        {
            
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            
            if (order == null || !await IsStoreOwnerOfOrderAsync(storeOwnerId, order.StoreId))
            {
                return false; 
            }

            
            if (order.Status == OrderStatus.Completed || order.Status == OrderStatus.Cancelled)
            {
                return false; 
            }

            
            order.Status = newStatus;

            await _orderRepository.UpdateOrderAsync(order);

            return true;
        }

        private async Task<bool> IsStoreOwnerOfOrderAsync(string storeOwnerId, int orderStoreId)
        {
            var store = await _storeRepository.GetStoreByIdAsync(orderStoreId); 
            return store.StoreOwnerId == storeOwnerId;
        }
    }
}
