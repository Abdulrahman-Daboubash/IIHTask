using Application.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService (IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public List<User> GetUsers()
        {
           var users = _userRepository.GetAll();
            return users;
        }

        public void InsertUser(User user)
        {
            var x = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CompanyId = user.CompanyId
            };
            _userRepository.Insert(x);

        }
        public void UpdateUser(int id,User user)
        {
            var x = _userRepository.GetById(id);
            if (x != null)
            {
                x.Name = user.Name;
                x.Role = user.Role;
                x.Email = user.Email;
                x.CompanyId = user.CompanyId;
            }
            _userRepository.Update(x);
            

        }

       
    }
}
