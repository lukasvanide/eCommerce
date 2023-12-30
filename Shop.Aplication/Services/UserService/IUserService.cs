using Microsoft.AspNetCore.Http;
using Shop.Aplication.Services.UserService.Dto;
using Shop.Domain;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Aplication.Services.UserService
{
    public interface IUserService
    {
        Task<LoginResult> Login(string username, string password);

        Task<LocalUsers> Register(string username, string password , string email);

    }
}
