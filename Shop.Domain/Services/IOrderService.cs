using Shop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.OrderService
{
    public interface IOrderService
    {
        Task Checkout(int userId);
        Task<IEnumerable<CartItem>> GetallChekaoutItems(int userId);

        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
    }
}
