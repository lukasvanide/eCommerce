using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;

namespace Shop.Controllers
{
    [Route("api/ShopAPI")]
    [ApiController]
    public class ShopAPIController : ControllerBase
    {

        private readonly IProductService _productService;
        public ShopAPIController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("search/")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Product>>> GetItems(int? id, int? minPrice,int? maxPrice, string? name)
        {
            var products = await _productService.GetAll(id, minPrice, maxPrice, name);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
