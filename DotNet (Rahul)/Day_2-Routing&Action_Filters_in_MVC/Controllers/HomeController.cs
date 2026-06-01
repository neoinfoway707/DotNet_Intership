using Day_2_Routing_Action_Filters_in_MVC.Filters;
using Day_2_Routing_Action_Filters_in_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Day_2_Routing_Action_Filters_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("PrivacyPolicy")]
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Products")]
        [HttpGet]
        public IActionResult Products()
        {
            var product = ProductRepository.GetAllProducts();
            return View("Products", product);
        }

        [Route("Product")]
        [CustomActionFilter]
        [HttpPost]
        public IActionResult Product(Product product)
        {
            ProductRepository.AddProduct(product);
            return RedirectToAction("Products");
        }
    }
}
