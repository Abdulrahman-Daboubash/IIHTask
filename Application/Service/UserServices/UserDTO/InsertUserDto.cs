using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.UserSrvice.UserDTO
{
    public class InsertUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
    }
}
