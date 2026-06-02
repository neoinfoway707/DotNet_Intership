using Day_3_Data_Binding_in_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_3_Data_Binding_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            ViewData["CurrentTime"] = DateTime.Now.ToString("F");
            ViewBag.Greeting = "Hello, welcome to our MVC Site!";
            TempData["Notice"] = "This message is stored in TempData and will be available for the Privacy policy page request.";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "This is the privacy page.";
            ViewBag.PolicyInfo = "Our privacy policy is simple: we respect your privacy.";
            TempData["PrivacyNotice"] = "This is a privacy notice that will be available for the next request.";
            return View();
        }
        public IActionResult Product()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Gaming Laptop", Price = 1499.99m, Category = "Electronics", Description = "Core i9, 32GB RAM, RTX 4080" },
                new Product { Id = 2, Name = "4K OLED Monitor", Price = 799.50m, Category = "Electronics", Description = "32-inch Ultra-HD Curved Display" },
                new Product { Id = 3, Name = "Mechanical Keyboard", Price = 125.00m, Category = "Accessories", Description = "RGB Cherry MX Blue Switches" },
                new Product { Id = 4, Name = "Premium Smartwatch", Price = 349.99m, Category = "Wearables", Description = "GPS with Titanium Case" },
                new Product { Id = 5, Name = "Noise Cancelling Headphones", Price = 299.00m, Category = "Audio", Description = "Wireless over-ear headphones" }
            };

            return View(products);
        }
    }
}
