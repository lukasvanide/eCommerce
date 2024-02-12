using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entity;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Data;


namespace Shop.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AplicationDbContext _db;

        public CartRepository(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddCartItem(CartItem cartItem)
        {
            _db.CartItems.Add(cartItem); 
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItems()
        {
            var getAllItems = await _db.CartItems.ToListAsync();
            return getAllItems;
        }



        public async Task RemoveCartItem(CartItem cartItem)
        {
            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            _db.CartItems.Update(cartItem);
            await _db.SaveChangesAsync();
        }

        public async Task<CartItem> GetCartItemByUserIdAndProductId(int userId, int productId)
        {
            return await _db.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsByUserId(int userId)
        {
            return await _db.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product) 
                .ToListAsync();


        }
        public async Task<CartItem> GetCartItemByUserIdAndCartItemId(int userId, int cartItemId)
        {
            return await _db.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.Id == cartItemId);
        }

        public async Task RemoveCart(int userId)
        {
            var cartItems = await GetAllCartItemsByUserId(userId);

            _db.CartItems.RemoveRange(cartItems);

            await _db.SaveChangesAsync();
        }
    }
}
