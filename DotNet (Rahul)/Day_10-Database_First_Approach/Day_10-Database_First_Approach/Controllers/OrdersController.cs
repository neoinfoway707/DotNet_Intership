using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day_10_Database_First_Approach.Data;
using Day_10_Database_First_Approach.Models;
using Day_10_Database_First_Approach.Repository;

namespace Day_10_Database_First_Approach.Controllers
{
    public class OrdersController(AppDbContext _context,IOrdersRepo _repo) : Controller
    {
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllOrders());
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.action = "Create";

            ViewBag.CustomerId = new SelectList(_context.Customers, "Id", "FullName");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {

            ViewBag.action = "Create";
            if (order == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var addOrder = await _repo.CreateOrder(order);
                if (addOrder)
                    return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.action = "Edit";

            if (id == null)
                return NotFound();

            var order = await _repo.IsOrderExists(id);
            if (order == null)
                return NotFound();

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            ViewBag.action = "Edit";

            if (id != order.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var updateOrder = await _repo.EditOrder(id, order);
                    if (!updateOrder)
                        return BadRequest();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.GetByIdOrder(id);
                    if (!check)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var order = await _repo.DeleteOrder(id);
            if (order)
                return RedirectToAction(nameof(Index));

            return View(order);
        }
    }
}
