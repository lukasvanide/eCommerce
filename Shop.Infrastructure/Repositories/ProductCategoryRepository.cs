using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AplicationDbContext _db;
        public ProductCategoryRepository(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            
            return await _db.Categories.ToListAsync();
        }
    }
}
