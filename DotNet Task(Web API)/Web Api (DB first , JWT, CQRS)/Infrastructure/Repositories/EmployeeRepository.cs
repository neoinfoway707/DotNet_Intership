using Application.Interfaces;
using Azure.Core;
using DB_Approach_CRUD.Application.DTOs;
using DB_Approach_CRUD.Persistance.Data;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB_Approach_CRUD.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeCrud>> GetAllEmployee()
        {
            var emps = await _context.EmployeeCruds
                .Where(x => x.IsDelete == false)
                .ToListAsync();
            return emps;
        }

        public async Task<EmployeeCrud?> GetEmployeeById(int id)
        {
            var emp = await _context.EmployeeCruds
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDelete == false);
            return emp;
        }

        public async Task<EmployeeCrud?> GetExists(EmployeeCrud employee)
        {
            String Name = employee.Name?.Trim() ?? string.Empty;
            String Department = employee.Department?.Trim() ?? string.Empty; 
            String Role = employee.Role?.Trim() ?? string.Empty;
            Decimal? Salary = employee.Salary;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Department) ||
                string.IsNullOrWhiteSpace(Role) || !Salary.HasValue)
            {
                return null;
            }
            var check = await  _context.EmployeeCruds.FirstOrDefaultAsync(e =>
                e.Name.ToLower() == Name.ToLower() &&
                e.Department.ToLower() == Department.ToLower() &&
                e.Role.ToLower() == Role.ToLower() &&
                e.Salary.Equals(Salary)
            );
            return check;
        }

        public async Task<bool> AddAsync(EmployeeCrud employee)
        {
            using var trans = await _context.Database.BeginTransactionAsync();
            await _context.EmployeeCruds.AddAsync(employee);
            await _context.SaveChangesAsync();
            await trans.CommitAsync();
            return true;
        }

        public async Task<bool> GemEmployeeIDExists(int id)
        {
            return await _context.EmployeeCruds.AnyAsync(e => e.Id == id);
        }

        public async Task<EmployeeCrud> UpdateEmployee(EmployeeCrud employee)
        {
            using var trans = _context.Database.BeginTransaction();

            var check = await _context.EmployeeCruds.FindAsync(employee.Id);
            if (check == null)
                return null;

            check.Name = employee.Name;
            check.Department = employee.Department;
            check.Role = employee.Role;
            check.Salary = employee.Salary;

            await _context.SaveChangesAsync();
            await trans.CommitAsync();
            return check;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using var trasn = _context.Database.BeginTransaction();
            var check = await _context.EmployeeCruds.FirstOrDefaultAsync(e=> e.Id == id && e.IsDelete == false);
            if (check == null)
                return false;
            check.IsDelete = true;
            await _context.SaveChangesAsync();
            await trasn.CommitAsync();
            return true;
        }
    }
}
