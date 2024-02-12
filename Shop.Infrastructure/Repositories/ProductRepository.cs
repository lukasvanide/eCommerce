using Shop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Models.Dto;
using Shop.Domain.Entity;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AplicationDbContext _db;

        public ProductRepository(AplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(Product product)
        {

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

        }

        public async Task Delete(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

     

        public async Task Update(Product product)
        {
            _db.Products.Update(product);

            await _db.SaveChangesAsync();

        }

        public async Task<Product> Get(int id)
        {
            var searchingItem = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            return searchingItem;

        }

    }
}
