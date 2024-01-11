using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Services.ProductCategoryService;
using Shop.Aplication.Services.ProductCartService;
using Shop.Aplication.Models.CartDto;
using Shop.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;
using Shop.Domain.Repositories;
using Shop.Aplication.Services.SessionService;

namespace Shop.Controllers
{
    [Route("api/CartItem")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IProductCartService _productCartService;
        private readonly ICookieRepository _cookieRepository;
        public CartController(IProductCartService ProductCartService, ICookieRepository cookieRepository)
        {
            _productCartService = ProductCartService;
            _cookieRepository = cookieRepository;


        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartRequestDto request)
        {


            await _productCartService.AddToCart(request.ProductId, request.Quantity);

            return Ok("Product added to the cart");


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
