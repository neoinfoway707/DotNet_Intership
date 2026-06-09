using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_9_Code_First_Approach.Controllers
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
