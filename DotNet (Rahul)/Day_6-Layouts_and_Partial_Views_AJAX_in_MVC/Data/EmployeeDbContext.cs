using Day_6_Layouts_and_Partial_Views_AJAX_in_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_6_Layouts_and_Partial_Views_AJAX_in_MVC.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
