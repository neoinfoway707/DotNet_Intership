using Microsoft.AspNetCore.Mvc;

namespace Day_1_DOT_NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
     
        public IActionResult Error()
        {
            return View();
        }
    }
}
