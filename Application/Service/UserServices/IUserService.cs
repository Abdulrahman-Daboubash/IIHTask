using Application.Service.UserSrvice.UserDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.UserSrvice
{
    public interface IUserService
    {
        public IQueryable<User> GetUsers();
        public User GetUser(Guid id);
        public void InsertUser (InsertUserDto user);
        public void UpdateUser (Guid id, InsertUserDto user);
        public void DeleteUser (Guid id);
    }
}
