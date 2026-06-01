using Employee_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD.Data
{
    public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
