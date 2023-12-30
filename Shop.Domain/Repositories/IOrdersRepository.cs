using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IOrdersRepository
    {
        Task Add(Order orders);
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);

    }
}
