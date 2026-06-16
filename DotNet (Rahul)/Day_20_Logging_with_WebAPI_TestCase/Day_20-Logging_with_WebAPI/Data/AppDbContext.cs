using Day_20_Logging_with_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_20_Logging_with_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SmartContainer> SmartContainers { get; set; }
    }
}