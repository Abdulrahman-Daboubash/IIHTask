using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Insert(T input);
        public void Update(T input);
        public void Delete(T input);
       
    }
}
