using Microsoft.AspNetCore.Mvc;
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
            var user = await _userService.Login(request.UserName, request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            var acssestoken = Guid.NewGuid().ToString();
            var cookieName = "turmanavuzamyuerebshi";
            this.Response.Cookies.Append(cookieName, acssestoken);
            return Ok(); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto request)
        {
            var user = await _userService.Register(request.Username, request.Password, request.Email);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> CheckLogin()
        {

            if (this.Request.Cookies.TryGetValue("turmanavuzamyuerebshi", out string acssestoken) && !string.IsNullOrEmpty(acssestoken))
            { 
                return Ok("User is logged in");
            }

            return Unauthorized("User is not logged in");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            this.Response.Cookies.Delete("turmanavuzamyuerebshi");
            return Ok();
        }
    }
}
