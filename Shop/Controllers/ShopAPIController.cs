using Microsoft.AspNetCore.Mvc;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;
using Microsoft.Extensions.Caching.Memory;
using Shop.Domain.Cashing;
using Shop.Domain.Entity;

namespace Shop.Controllers
{
    [Route("api/Shop")]
    [ApiController]
    public class ShopAPIController : ControllerBase
    {
        private readonly ILogger<ShopAPIController> _logger;
        private readonly IProductService _productService;


        public ShopAPIController(IProductService productService, ILogger<ShopAPIController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("search/")]

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems(int? id, double? minPrice, double? maxPrice, string? name, int? categoryId, string? categoryName)
        {

            var products = await _productService.GetAll(id, minPrice, maxPrice, name, categoryId, categoryName);

            return Ok(products);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductInput input)
        {

            await _productService.Create(input);

            return Ok();


        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }


    }
}
