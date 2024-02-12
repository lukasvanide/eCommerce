using Microsoft.Extensions.Logging;
using Shop.Aplication.Services.SessionService;
using Shop.Domain.Cashing;
using Shop.Domain.Entity;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System.Collections.Generic;

namespace Shop.Aplication.Services.ProductCartService
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ISessionService _sessionService;
        private readonly ILogger<ProductCartService> _logger;
        private readonly IInMemoryCaching<List<CartItem>> _cache;

        public ProductCartService(IProductRepository productRepository,
            ICartRepository CartRepository,
            ISessionService sessionService,
            ILogger<ProductCartService> logger ,
            IInMemoryCaching<List<CartItem>> cache)
        {
            _cartRepository = CartRepository;
            _productRepository = productRepository;
            _sessionService = sessionService;
            _logger = logger;
            _cache = cache;
        }
        public async Task AddToCart(int productId, int quantity)
        {
            var product = await _productRepository.Get(productId);
            var userId = await _sessionService.GetCurrentUserId();
            var cartItem = await _cartRepository.GetCartItemByUserIdAndProductId(userId, productId);
            if (quantity <= 0)
            {
                throw new BadRequestException("bad request");
            }
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _cartRepository.AddCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
                await _cartRepository.UpdateCartItem(cartItem);
            }

        }

        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            string cached = "Accept";
            var cartItems = await _cache.Get(cached);

            if (cartItems != null)
            {

                return cartItems;
            }
            else
            {
                cartItems = (await _cartRepository.GetAllCartItems()).ToList();
                await _cache.Set(cached, cartItems, TimeSpan.FromMinutes(10));
                return cartItems;
            }
        }

        public async Task RemoveFromCart(int cartItemId, int userId)
        {
            var cartItem = await _cartRepository.GetCartItemByUserIdAndCartItemId(cartItemId, userId);
            if (cartItem != null)
            {
                await _cartRepository.RemoveCartItem(cartItem);
            }
        }
    }
}
