using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Models.UsersDto;


namespace Shop.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<LocalUsers> GetUserByUsernameAndPassword(string username, string password);

        Task<LocalUsers> GetUserByUsername(string username);

        Task<LocalUsers> GetUserByEmail(string email);

        Task AddUser(LocalUsers localuser);

        Task<bool> IsUsernameTaken(string username);

        Task<bool> IsEmailRegistered(string email);

    }
}
