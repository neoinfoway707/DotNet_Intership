using Day23_NET_Core_and_Repository_Pattern.Models;
using Microsoft.EntityFrameworkCore;

namespace Day23_NET_Core_and_Repository_Pattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Track> Tracks { get; set; }
    }
}
