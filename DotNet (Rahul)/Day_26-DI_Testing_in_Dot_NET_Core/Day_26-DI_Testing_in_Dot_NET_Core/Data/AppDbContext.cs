using Day_26_DI_Testing_in_Dot_NET_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
