﻿using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Shop.Aplication.Services.ProductService;
using Shop.Aplication.Models.Dto;
using Shop.Aplication.Services.ProductCategoryService;
using Shop.Aplication.Services.ProductCartService;
using Shop.Aplication.Models.CartDto;
using Shop.Domain.Exceptions;
using Shop.Aplication.Services.UserService;
using Shop.Domain.Models.UsersDto;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var loginResult = await _userService.Login(request.UserName, request.Password);


            if (loginResult == null)
            {
                return Unauthorized("Invalid username or password");
            }

           
            var cookieOptions = new CookieOptions
            {
                SameSite = SameSiteMode.None,
                HttpOnly = false,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddHours(1), 
                Domain = "http://localhost:3004"

            };
            var cookieName = "cookieees";
            this.Response.Cookies.Append(cookieName, loginResult.AccessToken.ToString(), cookieOptions);
            return Ok(); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto request)
        {
            var user = await _userService.Register(request.Username, request.Email, request.Password);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> CheckLogin()
        {

            if (this.Request.Cookies.TryGetValue("cookieees", out string acssestoken) && !string.IsNullOrEmpty(acssestoken))
            { 
                return Ok("User is logged in");
            }

            return Unauthorized("User is not logged in");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            this.Response.Cookies.Delete("cookieees");
            return Ok();
        }
    }
}
