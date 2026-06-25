using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagement.WebApi.Wrapper;

namespace ProductManagement.Web.Filter
{
    public class ValidateIdActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("id", out var idValue) || idValue is not int id)
            {
                context.Result = new BadRequestObjectResult(new ProductResponse<object>("Invalid or missing parameter 'id'."));
                return;
            }

            if (id <= 0)
            {
                context.Result = new BadRequestObjectResult(new ProductResponse<object>("Id must be greater than zero."));
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
