using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderService.OrderDTOs
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
