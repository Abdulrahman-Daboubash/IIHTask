using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails()
        {
            var details = _orderDetailService.GetOrderDetails();
            return Ok(details);
        }

        [HttpGet("GetOrderDetail/{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            var detail = _orderDetailService.GetOrderDetail(id);
            if (detail == null)
            {
                return NotFound();
            }
            return Ok(detail);
        }

        [HttpGet("GetDetailsByOrderId/{orderId}")]
        public IActionResult GetDetailsByOrderId(int orderId)
        {
            var details = _orderDetailService.GetDetailsByOrderId(orderId);
            return Ok(details);
        }

        [HttpPut("UpdateOrderDetail/{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetail orderDetail)
        {
            _orderDetailService.UpdateOrderDetail(id, orderDetail);
            return Ok(new { message = "تم تحديث تفاصيل الطلب بنجاح." });
        }

        [HttpDelete("DeleteOrderDetail/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            _orderDetailService.DeleteOrderDetail(id);
            return Ok(new { message = "تم حذف تفاصيل الطلب بنجاح." });
        }
    }
}
