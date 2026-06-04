using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_6_Layouts_and_Partial_Views_AJAX_in_MVC.Controllers
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
