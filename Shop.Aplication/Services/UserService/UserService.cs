using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Aplication.Repository;
using Shop.Domain;
using Shop.Domain.Repositories;
using Shop.Aplication.Services.UserService.Dto;
using System.Security.Cryptography;

namespace Shop.Aplication.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICookieRepository _cookieRepository;

        public UserService(IUserRepository userRepository, ICookieRepository cookieRepository)
        {
            _userRepository = userRepository;
            _cookieRepository = cookieRepository;
        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user == null || MD5Hash(password) != user.Password)
            {
                throw new Exception("Invalid username or password");
            }
            var cookies = new Cookies
            {
                UserId = user.Id,
                LoginTime = DateTime.Now,
                AccessToken = Guid.NewGuid(),
            };
            await _cookieRepository.CookiesHistory(cookies);

            return new LoginResult { AccessToken = cookies.AccessToken.Value};
        }

        public async Task<LocalUsers> Register(string username, string email, string password)
        {
            if (await _userRepository.IsUsernameTaken(username))
            {
                throw new Exception("name is taken");
            }


            if (await _userRepository.IsEmailRegistered(email))
            {
                throw new Exception("email is taken");
            }

            string hashedPassword = MD5Hash(password);

            var newUser = new LocalUsers
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            };

            await _userRepository.AddUser(newUser);

            return newUser;
        }

        static string MD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }

}
