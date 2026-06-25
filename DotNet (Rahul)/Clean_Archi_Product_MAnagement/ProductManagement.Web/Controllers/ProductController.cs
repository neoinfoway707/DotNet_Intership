using Microsoft.AspNetCore.Mvc;
using ProductManagement.Web.ViewModels;

namespace ProductManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new RequestViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}