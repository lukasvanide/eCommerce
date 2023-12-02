using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Migrations;

namespace Shop.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AplicationDbContext _db;

        public CartRepository(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Domain.CartItem>> GetAllCartItems()
        {
            var getAllItems = await _db.CartItems.ToListAsync();
            return getAllItems;
        }

        public async Task<Domain.CartItem> GetCartItemByProductId(int cartItemId)
        {
            var  cartItemByProductId = _db.CartItems.FirstOrDefault(x => x.Id == cartItemId);
            return cartItemByProductId;
        }

        public async Task  RemoveCartItem(Domain.CartItem cartItem)
        {
            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();
        }
    }
}
