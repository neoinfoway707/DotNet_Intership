using Day_25_CRUD_Operations_with_Repository_Pattern.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
