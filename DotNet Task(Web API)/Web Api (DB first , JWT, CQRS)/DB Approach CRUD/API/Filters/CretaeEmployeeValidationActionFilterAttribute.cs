using Application.Features.Employees.Commands.CreateEmployee;
using Application.Interfaces;
using DB_Approach_CRUD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DB_Approach_CRUD.API.Filters
{
    public class CretaeEmployeeValidationActionFilterAttribute(IEmployeeRepository employeeRepository) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var employee = context.ActionArguments["command"] as CreateEmployeeCommand;


            if (employee != null)
            {
                var emp = new EmployeeCrud
                {
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    Salary = employee.Salary
                };
                var exists = await employeeRepository.GetExists(emp);

                if (exists != null)
                {
                    context.ModelState.AddModelError("Employee", "Employee details are incorrect or already exist.");
                    ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status409Conflict
                    };
                    context.Result = new ConflictObjectResult(problemDetails);
                    return;
                }
            }
            await next();
        }
    }
}
