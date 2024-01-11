using Microsoft.AspNetCore.Http;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.ProductCartService
{
    public interface IProductCartService
    {
        Task AddToCart(int productId, int quantity);
        
        Task RemoveFromCart(int cartItemId, int userId);

        Task<IEnumerable<CartItem>> GetCartItems();

    }
}
