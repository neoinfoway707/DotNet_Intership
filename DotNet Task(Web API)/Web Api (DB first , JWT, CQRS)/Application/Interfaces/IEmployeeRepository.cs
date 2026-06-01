using DB_Approach_CRUD.Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeCrud>> GetAllEmployee();

        Task<EmployeeCrud?> GetEmployeeById(int id);

        Task<bool> AddAsync(EmployeeCrud employee);
        Task<EmployeeCrud?> GetExists(EmployeeCrud employee);
        Task<EmployeeCrud> UpdateEmployee(EmployeeCrud employee);
        Task<bool> GemEmployeeIDExists(int id);

        Task<bool> DeleteEmployee(int id);
    }
}
