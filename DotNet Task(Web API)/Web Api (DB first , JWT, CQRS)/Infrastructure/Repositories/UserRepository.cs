using DB_Approach_CRUD.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;

namespace DB_Approach_CRUD.Persistance.Repositories
{
    public class UserRepository(EmployeeDbContext _context) : IUserRepository
    {
        public async Task<User?> GetUserByCredentials(User user)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == user.Username.ToLower()
                        || u.Password == user.Password);
        }
        public async Task<bool> AddUser(User user)
        {
            if (user == null)
                return false;

            using var trans = await _context.Database.BeginTransactionAsync();

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            return true;
        }
    }
}
