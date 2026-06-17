using Day_22_Implement_Login_functionality_with_WebAPI.Data;
using Day_22_Implement_Login_functionality_with_WebAPI.Dtos;
using Day_22_Implement_Login_functionality_with_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_22_Implement_Login_functionality_with_WebAPI.Repositories
{
    public class UserRepository(AppDbContext _context, ILogger<UserRepository> _logger) : IUserRepository
    {
        public async Task<User> RegisterNewUser(UserRequestDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };
            _logger.LogInformation("Saving New User {Username} with Id {Id}. to database.", user.Username, user.Id);
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("User {Username} saving with Id {ID}.", user.Username, user.Id);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Register new User {usernmae}", userDto.Username);
                throw;
            }
        }

        public async Task<User?> LoginUser(UserRequestDto userDto)
        {
            _logger.LogInformation("Querying database to check user credentials.");
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == userDto.Username);
            if (user == null)
            {
                _logger.LogWarning("User {username} not found in database.", userDto.Username);
                return null;
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                _logger.LogWarning("User Password of User {username} not match.", user.Username);
                return null;
            }
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            _logger.LogInformation("Querying database for All User data.");
            return await _context.Users.Where(u => u.Role != "Admin").ToListAsync();
        }

        public async Task<User?> UpdateUser(int id, UserRequestDto userDto)
        {
            _logger.LogInformation("Querying database to update User with {Id}.", id);

            var GetUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (GetUser == null)
            {
                _logger.LogWarning("User Id {Id} not found in database.", id);
                return null;
            }
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                GetUser.Username = userDto.Username;
                GetUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("User Id {Id} Updated Successfully.", GetUser.Id);
                return GetUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update User {usernmae}", userDto.Username);
                throw;
            }
        }
    }
}
