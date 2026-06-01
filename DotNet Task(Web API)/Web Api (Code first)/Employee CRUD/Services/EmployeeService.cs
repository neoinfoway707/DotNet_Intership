using Employee_CRUD.Data;
using Employee_CRUD.Models;
using Employee_CRUD.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace Employee_CRUD.Services
{
    public class EmployeeService(EmployeeDbContext context) : IEmployeeService
    {
        public async Task<Employee?> GetExistsEmp(String? Name, String? Department, String? Role, double? Salary)
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Department) ||
                string.IsNullOrWhiteSpace(Role) ||
                !Salary.HasValue || Salary <= 0)
                return new Employee();

            var check = await context.Employees.FirstOrDefaultAsync(e =>
                e.Name.ToLower() == Name.ToLower() &&
                e.Department.ToLower() == Department.ToLower() &&
                e.Role.ToLower() == Role.ToLower() &&
                e.Salary == Salary
            );
            return check;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await context.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null) return null;
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployee()
            => await context.Employees.ToListAsync();

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await context.Employees.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var FindEmp = await context.Employees.FindAsync(id);
            if (FindEmp == null) return false;
            FindEmp.Name = employee.Name;
            FindEmp.Department = employee.Department;
            FindEmp.Role = employee.Role;
            FindEmp.Salary = employee.Salary;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
