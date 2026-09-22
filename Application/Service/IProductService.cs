using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public interface IProductService
    {
        public List<Product> GetProducts(int pageNumber, int pageSize);
        public Product GetProduct(int id);
        public void InsertProduct(Product product);
        public void UpdateProduct(int id, Product product);
        public void DeleteProduct(int id);
    }
}
