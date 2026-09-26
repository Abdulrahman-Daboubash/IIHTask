using Application.Service.ProductService.ProductDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.ProductService.ProductService
{
    public interface IProductService
    {
        public List<Product> GetProducts(int pageNumber, int pageSize);
        public Product GetProduct(Guid id);
        public void InsertProduct(ProductDto product);
        public void UpdateProduct(Guid id, ProductDto product);
        public void DeleteProduct(Guid id);
    }
}
