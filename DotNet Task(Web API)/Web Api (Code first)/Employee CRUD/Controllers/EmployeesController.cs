using Employee_CRUD.Models;
using Employee_CRUD.Models.ActionFilter;
using Employee_CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
            => Ok(await employeeService.GetAllEmployee());

        [HttpGet("{id}")]
        [TypeFilter(typeof(ValidateEmployeeIdActionFilterAttribute))]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [TypeFilter(typeof(CreateEmployeeActionFilterAttribute))]
        [HttpPost]
        public async Task<ActionResult> AddNewEmployee([FromBody] Employee emp)
        {
            var employee = await employeeService.AddEmployee(emp);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidateEmployeeIdActionFilterAttribute))]
        public async Task<ActionResult> UpdateEmployee(int id, Employee emp)
        {
            return await employeeService.UpdateEmployee(id, emp) ? Ok("Employee Updated Successfully.") 
                : BadRequest("Error occurred  at update time");
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(ValidateEmployeeIdActionFilterAttribute))]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var deleteEmp = await employeeService.DeleteEmployee(id);
            if (deleteEmp == null) return NotFound($"Employee with id {id} not found.");
            return Ok(new { Message = "Employee Deleted Successfully." ,Data=deleteEmp });
        }
    }
}
