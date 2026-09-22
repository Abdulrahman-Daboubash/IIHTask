using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUser(int id);
        public void InsertUser (User user);
        public void UpdateUser (int id,User user);
        public void DeleteUser (int id);
    }
}
