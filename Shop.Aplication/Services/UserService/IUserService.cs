using Microsoft.AspNetCore.Http;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.UserService
{
    public interface IUserService
    {
        Task<LocalUsers> Login(string username, string password);

        Task<LocalUsers> Register(string username, string password , string email);

    }
}
