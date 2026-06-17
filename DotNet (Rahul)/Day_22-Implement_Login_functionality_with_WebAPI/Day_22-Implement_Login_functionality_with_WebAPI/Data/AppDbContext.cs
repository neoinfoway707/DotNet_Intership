using Day_22_Implement_Login_functionality_with_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_22_Implement_Login_functionality_with_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
