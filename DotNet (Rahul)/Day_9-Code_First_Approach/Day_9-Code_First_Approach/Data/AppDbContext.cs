using Day_9_Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_9_Code_First_Approach.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
