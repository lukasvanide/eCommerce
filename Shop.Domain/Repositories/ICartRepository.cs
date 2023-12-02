using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<CartItem> GetCartItemByProductId(int cartItemId);

        Task RemoveCartItem(CartItem cartItem);

        Task <IEnumerable<CartItem>> GetAllCartItems();
    }
}
