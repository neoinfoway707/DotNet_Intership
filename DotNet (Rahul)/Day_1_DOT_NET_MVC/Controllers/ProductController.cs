using Day_1_DOT_NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_1_DOT_NET_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Display()
        {
            List<Product> allProduct = ProductRepo.GetAllProducts();
            return View(allProduct);
        }
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Action = "Create";
            if (ModelState.IsValid)
            {
                if (ProductRepo.CreateProduct(product))
                    return RedirectToAction("Display");
                else
                {
                    ModelState.AddModelError("Created Product", "Product Already exists.");
                    return View("Create", product);
                }
            }
            return View("Create", product);
        }
        [HttpGet]
        public ActionResult Update([FromRoute] int id)
        {
            ViewBag.Action = "Update";
            Product? product = ProductRepo.GetProductById(id);
            if (product == null)
                return RedirectToAction("Display");
            return View("Update", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.UpdateProduct(product.Id, product);
                return RedirectToAction("Display");
            }
            ViewBag.Action = "Update";
            return View("Update", product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool deleteProduct = ProductRepo.DeleteProduct(id);
            return RedirectToAction("Display");
        }
    }
}
