using Shop.Aplication.Repository;
using Shop.Domain;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.ProductCartService
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _CartRepository;

        public ProductCartService(IProductRepository productRepository, ICartRepository CartRepository)
        {
            _CartRepository = CartRepository;
            _productRepository = productRepository;
        }
        public async Task AddToCart(int productId, int quantity, int userId)
        {
            var product = await _productRepository.Get(productId);

            var cartItem = await _CartRepository.GetCartItemByUserIdAndProductId(userId, productId);
            if(quantity <= 0)
            {
                throw new BadRequestException("vaja ylea vici");
            }
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _CartRepository.AddCartItem(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
                await _CartRepository.UpdateCartItem(cartItem);
            }
        }

        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            return await _CartRepository.GetAllCartItems();
        }

        public async Task RemoveFromCart(int cartItemId, int userId)
        {
            var cartItem = await _CartRepository.GetCartItemByUserIdAndCartItemId(cartItemId, userId);
            if (cartItem != null)
            {
                await _CartRepository.RemoveCartItem(cartItem);
            }
        }

    }
}
