using Shop.Domain;
using Shop.Domain.Entity;
using Shop.Domain.Exceptions;
using Shop.Domain.Repositories;
using Shop.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.OrderService
{
    public class OrderService : IOrderService
    {

        public readonly IOrdersRepository _ordersRepository;
        public readonly ICartRepository _cartRepository;
        public readonly ITransaction _transaction;
        public OrderService(IOrdersRepository OrdersRepository, ICartRepository CartRepository, ITransaction transaction)
        {
            _ordersRepository = OrdersRepository;
            _cartRepository = CartRepository;
            _transaction = transaction;

        }
        public async Task Checkout(int userId)
        {
            await _transaction.StartTransactionAsync();
            try
            {
                var cartItems = await _cartRepository.GetAllCartItemsByUserId(userId);
                if (cartItems.Any())
                {
                    var order = new Order
                    {
                        UserId = userId,
                        OrderDate = DateTime.Now,
                        OrderItems = cartItems.Select(ci => new OrderItems
                        {
                            ProductId = ci.ProductId,
                            Quantity = ci.Quantity,
                            Price = ci.Product.Price
                        }).ToList()
                    };

                    await _ordersRepository.Add(order);
                    await _cartRepository.RemoveCart(userId);
                    await _transaction.CommitTransactionAsync();

                }
            }
            catch (Exception) 
            {
                await _transaction.RollbackTransactionAsync();
                throw;
            }
        }
        public async Task<IEnumerable<CartItem>> GetallChekaoutItems(int userId)
        {
           return await _cartRepository.GetAllCartItemsByUserId(userId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
           return await _ordersRepository.GetOrdersByUserId(userId);
        }
    }
}
