using Application.Service;
using Application.Service.OrderDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("GetOrdersByUser/{userId}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            var orders = _orderService.GetOrdersByUser(userId);
            return Ok(orders);
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
        {
            _orderService.CreateOrder(dto);
            return Ok();
        }

        [HttpPut("UpdateOrder/{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            _orderService.UpdateOrder(id, order);
            return Ok();
        }

        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
