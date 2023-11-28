using Shop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Infrastructure.Data;

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

        public async Task<IEnumerable<Product>> GetAll(int? id, int? minPrice,int? maxPrice, string? name, int? categoryId)
        {
            var query = _db.Products.AsQueryable();

            if (id.HasValue)
            {
               query = query.Where(p => p.Id == id.Value);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            return await query.ToListAsync();


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
