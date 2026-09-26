using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order order { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
