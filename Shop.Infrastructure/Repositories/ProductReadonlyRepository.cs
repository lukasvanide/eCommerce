using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Repository;
using Shop.Domain;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories
{
    public class ProductReadonlyRepository : IProductReadonlyRepository
    {
        private readonly AplicationDbContext _db;

        public ProductReadonlyRepository(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductDto>> GetAll(int? id, int? minPrice, int? maxPrice, string? name, int? categoryId, string? categoryName)
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

            if (!string.IsNullOrEmpty(categoryName))
            {

                query = query.Include(p => p.Category)
                             .Where(p => p.Category != null && p.Category.CategoryName == categoryName);
            }
            var  products = await query.Select(x => new ProductDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                quantity = x.quantity,
            }).ToListAsync();



            return products;

        }
    }
}
