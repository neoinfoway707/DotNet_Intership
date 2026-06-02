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
            //This message is stored in TempData and will be available for the Privacy policy page request
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
    }
}
