using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderServices.OrderDTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public Guid UserId { get; set; }
    }
}
