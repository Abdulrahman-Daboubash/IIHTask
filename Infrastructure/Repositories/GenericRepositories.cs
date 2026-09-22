using Application.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class GenericRepositories<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Delete(T input)
        {
            _dbSet.Remove(input);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var data = _dbSet.ToList();
            return data;
        }

        public T GetById(int id)
        {
            var user = _dbSet.Find(id);
            return user;
        }

        public void Insert(T input)
        {
            _dbSet.Add(input);
            _context.SaveChanges();

        }
        public void Update(T input)
        {
            _dbSet.Update(input);
            _context.SaveChanges();
        }
    }
}
