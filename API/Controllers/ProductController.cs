using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest();
            }
            var products = _productService.GetProducts(pageNumber , pageSize);
            return Ok(products);
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody]Product input)
        {
            _productService.InsertProduct(input);
            return Ok();
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult EditProduct(int id,[FromBody] Product input)
        {
            _productService.UpdateProduct(id, input);
            return Ok();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
