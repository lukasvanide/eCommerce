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
    public class CookieRepository : ICookieRepository
    {
        private readonly AplicationDbContext _db;

        public CookieRepository(AplicationDbContext db)
        {
            _db = db;
        }
        public async Task CookiesHistory(Cookies cookies)
        {
            await _db.Cookies.AddAsync(cookies);
            await _db.SaveChangesAsync();
        }
    }
}
