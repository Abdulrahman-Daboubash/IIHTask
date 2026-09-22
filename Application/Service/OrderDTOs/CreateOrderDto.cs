using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderDTOs
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
