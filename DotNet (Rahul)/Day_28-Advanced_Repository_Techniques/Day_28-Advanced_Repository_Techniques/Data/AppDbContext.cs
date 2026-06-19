using Day_28_Advanced_Repository_Techniques.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_28_Advanced_Repository_Techniques.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MedicleSupply> MedicalSupplies { get; set; }
    }
}
