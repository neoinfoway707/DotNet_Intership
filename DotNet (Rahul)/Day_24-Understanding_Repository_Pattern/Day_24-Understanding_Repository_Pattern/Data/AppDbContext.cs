using Day_24_Understanding_Repository_Pattern.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_24_Understanding_Repository_Pattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Track> Tracks { get; set; }
    }
}
