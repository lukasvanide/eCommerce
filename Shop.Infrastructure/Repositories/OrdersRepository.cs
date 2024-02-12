using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entity;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AplicationDbContext _db;
        public OrdersRepository(AplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(Order orders)
        {

                _db.Order.Add(orders);
                await _db.SaveChangesAsync();
            
        }


        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await _db.Order
                .Include(o => o.OrderItems) 
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    } }
