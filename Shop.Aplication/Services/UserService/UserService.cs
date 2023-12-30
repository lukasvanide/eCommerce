using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Aplication.Repository;
using Shop.Domain;
using Shop.Domain.Repositories;
using BCrypt.Net;



namespace Shop.Aplication.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LocalUsers> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Invalid username or password");
            }

            return user;
        }

        public async Task<LocalUsers> Register(string username, string password, string email)
        {
            if (await _userRepository.IsUsernameTaken(username))
            {
                throw new Exception("saxeli agebulia");
            }


            if (await _userRepository.IsEmailRegistered(email))
            {
                throw new Exception("emaili agebulia");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new LocalUsers
            {
                Username = username,
                Password = hashedPassword, 
                Email = email
            };

            await _userRepository.AddUser(newUser);

            return newUser;
        }


    }

}
