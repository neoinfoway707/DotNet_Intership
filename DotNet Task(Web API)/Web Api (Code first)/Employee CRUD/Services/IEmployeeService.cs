using Employee_CRUD.Models;

namespace Employee_CRUD.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> GetExistsEmp(String? Name, String? Department, String? Role, double? Salary);
        Task<bool> EmployeeExists(int id);
        Task<bool> UpdateEmployee(int id, Employee employee);
        Task<Employee?> DeleteEmployee(int id);
    }
}
