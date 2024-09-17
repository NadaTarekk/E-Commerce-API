using E_Commerce_API.Dtos.Order;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDto createOrderDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var order = await _orderService.CreateOrderAsync(createOrderDto);

            return Ok(order);

        }
        [Authorize]
        [HttpPut("cancel/{orderId:int}")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {

            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _orderService.CancelOrderAsync(orderId, customerId);

            if (!result)
            {
                return BadRequest(new { Message = "Order could not be cancelled. Either it does not exist, does not belong to you, or has already been completed or cancelled." });
            }

            return Ok(new { Message = "Order cancelled successfully." });
        }
        [Authorize(Roles = "StoreOwner")]
        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusDto updateOrderStatusDto)
        {

            var storeOwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _orderService.UpdateOrderStatusAsync(orderId, updateOrderStatusDto.NewStatus, storeOwnerId);

            if (!result)
            {
                return BadRequest("Order could not be updated. Either it does not exist, or you are not authorized to update its status.");
            }

            return Ok("Order status updated successfully.");

        }
    }
}

            
            
        