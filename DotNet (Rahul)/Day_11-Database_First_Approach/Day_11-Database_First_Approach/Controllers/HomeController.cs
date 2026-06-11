using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_11_Database_First_Approach.Controllers
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
