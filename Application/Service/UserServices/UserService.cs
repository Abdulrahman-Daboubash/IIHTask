using Application.Repository;
using Application.Service.UserSrvice.UserDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.UserSrvice
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService (IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(Guid id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
        }

        public User GetUser(Guid id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public IQueryable<User> GetUsers()
        {
           var users = _userRepository.GetAll().Include(x => x.company);
            
            return users;
        }

        public void InsertUser(InsertUserDto user)
        {
            if(_userRepository.GetAll().Any(x => x.Email == user.Email))
            {
                throw new Exception("The Email is Already Exist");
            }
            var x = new User()
            {
               
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CompanyId = user.CompanyId
            };
            _userRepository.Insert(x);

        }
        public void UpdateUser(Guid id,InsertUserDto user)
        {

            if (_userRepository.GetAll().Any(x => x.Email == user.Email && x.Id != id))
            {
                throw new Exception("The Email is Already Exist");
            }
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
