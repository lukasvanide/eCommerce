using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entity;

namespace Shop.Domain.Repositories
{
    public interface ICartRepository
    {
        Task RemoveCartItem(CartItem cartItem);

        Task <IEnumerable<CartItem>> GetAllCartItems();

        Task AddCartItem(CartItem cartItem);

        Task UpdateCartItem(CartItem cartItem);


        Task<CartItem> GetCartItemByUserIdAndProductId(int userId, int productId);

        Task<IEnumerable<CartItem>> GetAllCartItemsByUserId(int userId);

        Task<CartItem> GetCartItemByUserIdAndCartItemId(int userId, int cartItemId);

        Task RemoveCart(int userId);
    }

}

