using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Domain;
using Shop.Domain.Models.UsersDto;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AplicationDbContext _db;

        public UserRepository(AplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            
        }

        public async Task AddUser(LocalUsers localuser)
        {
            await _db.LocalUsers.AddAsync(localuser);
            await _db.SaveChangesAsync();
        }
    

        public async Task<LocalUsers> GetUserByEmail(string email)
        {
            return await _db.LocalUsers
           .SingleOrDefaultAsync(u => u.Email == email);

        }

        public async Task<LocalUsers> GetUserByUsername(string username)
        {
            return await _db.LocalUsers
             .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<LocalUsers> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _db.LocalUsers
             .SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return _db.LocalUsers.Any(u => u.Email == email);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return _db.LocalUsers.Any(u => u.Username == username);
        }

        public async Task CookiesHistory(Cookies cookies)
        {
            await _db.Cookies.AddAsync(cookies);
            await _db.SaveChangesAsync();
        }
    }
}
