using Employee_CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Employee_CRUD.Models.ActionFilter
{
    public class ValidateEmployeeIdActionFilterAttribute(IEmployeeService service) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments["id"] as int?;
            if (!id.HasValue || id <= 0)
            {
                context.ModelState.AddModelError("id", "Id Is invalid");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }
            var exists = await service.EmployeeExists(id.Value);
            if (!exists)
            {
                context.ModelState.AddModelError("id", "Employee Id does not exist");
                ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetails);
                return;
            }
            await next();
        }
    }
}
