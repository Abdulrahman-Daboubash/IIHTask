using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}
