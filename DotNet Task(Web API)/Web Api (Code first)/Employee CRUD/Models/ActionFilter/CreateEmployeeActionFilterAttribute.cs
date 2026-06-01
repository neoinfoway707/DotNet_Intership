using Employee_CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Employee_CRUD.Models.ActionFilter
{
    public class CreateEmployeeActionFilterAttribute(IEmployeeService service) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var emp = context.ActionArguments["emp"] as Employee;
            if (emp != null)
            {
                var exists = await service.GetExistsEmp(emp.Name, emp.Department, emp.Role, emp.Salary);
                if (exists != null)
                {
                    context.ModelState.AddModelError("Employee", "Employee details are empty or already exist.");
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
