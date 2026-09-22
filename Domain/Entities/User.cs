using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company company { get; set; }
    }
}
