using Day_21_CRUD_with_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_21_CRUD_with_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Track> Tracks { get; set; }
    }
}
