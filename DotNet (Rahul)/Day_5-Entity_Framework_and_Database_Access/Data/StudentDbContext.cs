using Day_5_Entity_Framework_Database_Access.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_5_Entity_Framework_Database_Access.Data
{

    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
