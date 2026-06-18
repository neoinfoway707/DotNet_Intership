using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MedicleSupply> MedicalSupplies { get; set; }
    }
}
