using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_5_Entity_Framework_Database_Access.Controllers
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
