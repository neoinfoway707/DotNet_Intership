using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day_10_Database_First_Approach.Models;
using Day_10_Database_First_Approach.Repository;

namespace Day_10_Database_First_Approach.Controllers
{
    public class CustomersController(ICustomersRepo _repo) : Controller
    {
        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllCustomers());
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.action = "Create";
            return View();  
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            ViewBag.action = "Create";
            if (customer == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var addCustomer = await _repo.CreateCustomer(customer);
                if (addCustomer)
                    return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.action = "Edit";

            if (id == null)
                return NotFound();

            var customer = await _repo.IsCustomerExists(id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            ViewBag.action = "Edit";

            if (id != customer.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                   var updateCustomer = await _repo.EditCustomer(id,customer);
                    if(!updateCustomer)
                        return BadRequest();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.GetByIdCustomer(id);
                    if (!check)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _repo.DeleteCustomer(id);
            if (customer)
                return RedirectToAction(nameof(Index));

            return View(customer);
        }
    }
}
