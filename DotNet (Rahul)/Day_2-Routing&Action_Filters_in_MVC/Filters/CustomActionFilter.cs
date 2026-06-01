using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day_2_Routing_Action_Filters_in_MVC.Filters
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var product = context.ActionArguments["product"] as Models.Product;
            var controller = context.Controller as Controller;

            if (product == null)
            {
                controller!.TempData["Error"] = "Product data is missing.";
                context.Result = new RedirectToActionResult("Products", "Home", null);
                return;
            }

            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Category))
            {
                controller!.TempData["Error"] = "Product Name and Category cannot be empty.";
                context.Result = new RedirectToActionResult("Products", "Home", null);
                return;
            }
            if (product.Price <= 100)
            {
                controller!.TempData["Error"] = "Product Price must be greater than 100.";
                context.Result = new RedirectToActionResult("Products", "Home", null);
                return;
            }

            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]");
            if (regex.IsMatch(product.Name) || regex.IsMatch(product.Category))
            {
                controller!.TempData["Error"] = "Product Name and Category cannot start with a number.";
                context.Result = new RedirectToActionResult("Products", "Home", null);
                return;
            }


            var exists = Models.ProductRepository.GetAllProducts().Any(p => p.Name != null && p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                controller!.TempData["Error"] = "Product with the same name already exists.";
                context.Result = new RedirectToActionResult("Products", "Home", null);
                return;
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(!context.Canceled)
                Console.WriteLine("Product Added Successfully.");
            base.OnActionExecuted(context);
        }
    }
}
