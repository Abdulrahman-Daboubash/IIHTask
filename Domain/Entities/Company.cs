using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
        
    }
}
