using Application.Service.OrderService.OrderDTOs;
using Application.Service.OrderService.OrderService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ordersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(Guid id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("{userId}")]
        public IActionResult GetOrdersByUser(Guid userId)
        {
            var orders = _orderService.GetOrdersByUser(userId);
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
        {
            _orderService.CreateOrder(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Guid id, [FromBody] Order order)
        {
            _orderService.UpdateOrder(id, order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
