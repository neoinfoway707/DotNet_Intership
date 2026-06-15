using Day_19_Working_with_EF_Core_in_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SmartContainer> SmartContainers { get; set; }
    }
}