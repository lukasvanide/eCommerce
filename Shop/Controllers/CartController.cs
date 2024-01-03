using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Services.ProductCategoryService;
using Shop.Aplication.Services.ProductCartService;
using Shop.Aplication.Models.CartDto;
using Shop.Domain.Exceptions;


namespace Shop.Controllers
{
    [Route("api/CartItem")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IProductCartService _productCartService;
        public CartController(IProductCartService ProductCartService)
        {
            _productCartService = ProductCartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartRequestDto request)
        {

                await _productCartService.AddToCart(request.ProductId, request.Quantity, request.UserId);
                return Ok();
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId, int userId)
        {

                await _productCartService.RemoveFromCart(userId, cartItemId);
                return Ok();

        }

        [HttpGet("CartAllItems")]
        public async Task<IActionResult> GetCart()
        {

                var cartItems = await _productCartService.GetCartItems();
                return Ok(cartItems);

        }
    }
}
