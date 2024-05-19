using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
               new Product() { Id = 1,ProductName="computer"},
               new Product() { Id = 2,ProductName="keyboard"},
               new Product() { Id = 3,ProductName="mouse"}
            };
            _logger.LogInformation("getallproducts actions has been called.");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {

            _logger.LogWarning("product has been created.");
            return StatusCode(201);
        }
    }

    
}


