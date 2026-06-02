using Day_4_Forms_and_Validation_in_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day_4_Forms_and_Validation_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Welcome " + user.Name + " You are now successfully logged in!";
                return RedirectToAction("Success");
            }
            return View(user);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
