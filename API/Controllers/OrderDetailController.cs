using Application.Service.OrderDetailService.OrderDetailService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ordersDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public ordersDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            var details = _orderDetailService.GetOrderDetails();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(Guid id)
        {
            var detail = _orderDetailService.GetOrderDetail(id);
            if (detail == null)
            {
                return NotFound();
            }
            return Ok(detail);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetDetailsByOrderId(Guid orderId)
        {
            var details = _orderDetailService.GetDetailsByOrderId(orderId);
            return Ok(details);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(Guid id, [FromBody] OrderDetail orderDetail)
        {
            _orderDetailService.UpdateOrderDetail(id, orderDetail);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(Guid id)
        {
            _orderDetailService.DeleteOrderDetail(id);
            return Ok();
        }
    }
}
