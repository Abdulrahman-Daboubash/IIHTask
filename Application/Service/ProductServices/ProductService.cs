using Application.Repository;
using Application.Service.ProductService.ProductDTO;
using Application.Service.ProductService.ProductService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product); 
        }

        public Product GetProduct(Guid id)
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

        public void InsertProduct(ProductDto product)
        {
            if(_productRepository.GetAll().Any(x => x.Name == product.Name))
            {
                throw new Exception("Product Already Exist");
            }
            var x = new Product()
            {
                
                Name = product.Name,
                Price = product.Price
                
            };
            _productRepository.Insert(x);
        }

        public void UpdateProduct(Guid id, ProductDto product)
        {
            if (_productRepository.GetAll().Any(x => x.Name == product.Name && x.Id != id))
            {
                throw new Exception("Product Already Exist");
            }
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

