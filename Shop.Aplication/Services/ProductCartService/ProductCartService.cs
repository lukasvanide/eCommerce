using Microsoft.AspNetCore.Http;
using Shop.Aplication.Repository;
using Shop.Aplication.Services.SessionService;
using Shop.Domain;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.ProductCartService
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ISessionService _sessionService;
        public ProductCartService(IProductRepository productRepository, ICartRepository CartRepository, ISessionService sessionService)
        {
            _cartRepository = CartRepository;
            _productRepository = productRepository;
            _sessionService = sessionService;
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
            return await _cartRepository.GetAllCartItems();
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
