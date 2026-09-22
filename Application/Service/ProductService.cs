using Application.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product); 
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public List<Product> GetProducts(int pageNumber, int pageSize)
        {
            var products = _productRepository.GetAll().Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList(); 
            return products;
        }

        public void InsertProduct(Product product)
        {
            var x = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
                
            };
            _productRepository.Insert(x);
        }

        public void UpdateProduct(int id, Product product)
        {
            var x = _productRepository.GetById(id);
            if (x != null)
            {
                x.Name = product.Name;
                x.Price = product.Price;
                
                _productRepository.Update(x);
            }
        }
    }
}

