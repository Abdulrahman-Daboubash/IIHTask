using Application.Service.ProductService.ProductDTO;
using Application.Service.ProductService.ProductService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private IProductService _productService;
        public productsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest();
            }
            var products = _productService.GetProducts(pageNumber, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto input)
        {
            _productService.InsertProduct(input);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(Guid id, [FromBody] ProductDto input)
        {
            _productService.UpdateProduct(id, input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
