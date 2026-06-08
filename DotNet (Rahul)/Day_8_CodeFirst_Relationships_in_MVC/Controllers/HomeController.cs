using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_8_CodeFirst_Relationships_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
