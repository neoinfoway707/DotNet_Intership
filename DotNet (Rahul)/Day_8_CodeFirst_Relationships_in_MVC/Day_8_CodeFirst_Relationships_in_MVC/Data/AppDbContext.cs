using Day_8_CodeFirst_Relationships_in_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_8_CodeFirst_Relationships_in_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
