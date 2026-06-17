using Day_22_Implement_Login_functionality_with_WebAPI.Dtos;
using Day_22_Implement_Login_functionality_with_WebAPI.Models;
using Day_22_Implement_Login_functionality_with_WebAPI.Repositories;
using Day_22_Implement_Login_functionality_with_WebAPI.Services;
using Day_22_Implement_Login_functionality_with_WebAPI.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day_22_Implement_Login_functionality_with_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository _repo, ITokenService _service, ILogger<UserController> _logger) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.GetAllUsers();
            var userResponse = users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role
            }).ToList();
            _logger.LogInformation("Fetching all Users Data.");
            return Ok(new UserResponse<List<UserResponseDto>>(userResponse, "Data Retrieved Successfully."));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserRequestDto userDto)
        {
            var checkUser = await _repo.LoginUser(userDto);
            if (checkUser == null)
            {
                _logger.LogWarning("User Credentials are not correct.");
                return Unauthorized(new UserResponse<string>("Invalid username or password.", new List<string> { "Authentication failed" }));
            }
            var tokens = _service.GenerateToken(checkUser.Username, checkUser.Role);

            _logger.LogInformation("User Login Successfully.");
            return Ok(new { token = tokens });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(UserRequestDto userDto)
        {
            var addUser = await _repo.RegisterNewUser(userDto);
            var userResponse = new UserResponseDto
            {
                Id = addUser.Id,
                Username = addUser.Username,
                Role = addUser.Role
            };
            var response = new UserResponse<UserResponseDto>(userResponse, "User Registered Successfully.");
            _logger.LogInformation("New User Register with default Role");
            return CreatedAtAction(nameof(LoginUser), new { Id = addUser.Id }, response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequestDto userDto)
        {
            var updateUser = await _repo.UpdateUser(id, userDto);
            if (updateUser == null)
            {
                _logger.LogWarning("User with Id {Id} Not Found.", id);
                return NotFound(new UserResponse<User>($"User With Id {id} not found."));
            }
            var userResponse = new UserResponseDto
            {
                Id = updateUser.Id,
                Username = updateUser.Username,
                Role = updateUser.Role
            };
            _logger.LogInformation("User {Username} with Id {Id} Updated.", updateUser.Username, updateUser.Id);
            return Ok(new UserResponse<UserResponseDto>(userResponse, "Data Updated Successfully."));
        }
    }
}