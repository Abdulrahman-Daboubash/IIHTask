using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderService.OrderDTOs
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
