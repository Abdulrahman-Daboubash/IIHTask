using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T GetById(Guid id);
        public void Insert(T input);
        public void Update(T input);
        public void Delete(T input);
        public void SaveChanges();
       
    }
}
