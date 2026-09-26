using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
        public SystemCompany? Code { get; set; }
        
    }

    public enum SystemCompany
    {
        IIH = 1,
        Amazon = 2,
        Tetra = 3
    }
}
