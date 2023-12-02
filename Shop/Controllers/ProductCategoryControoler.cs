using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Services.ProductCategoryService;


namespace Shop.Controllers
{
    [Route("api/ProductCategory")]
    [ApiController]
    public class ProductCategoryControoler : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryControoler(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetItems()
        {

            var productCategory =   await _productCategoryService.GetAllCategories();
            return Ok(productCategory);
        }

    }
}
