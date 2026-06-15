using Day_18_Authentication_and_Authorization_in_Web_APIs.Dtos;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Models;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllerController(ITokenService _service) : ControllerBase
    {
        private static List<User> _users = new List<User>{
            new User { Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Username = "rahul", Password = "rahul123", Role = "Employee" }
        };

        [HttpPost("login")]
        public IActionResult Login(UserDto user)
        {
            var find = _users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (find == null)
                return Unauthorized("Invalid username or password.");
            var tokens = _service.GenerateToken(user.Username, find.Role);
            return Ok(new { token = tokens });
        }
    }
}