using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day_11_Database_First_Approach.Data;
using Day_11_Database_First_Approach.Models;
using Day_11_Database_First_Approach.Repositories;
using System.Composition;

namespace Day_11_Database_First_Approach.Controllers
{
    public class PrescriptionsController(AppDbContext _context, IPrescriptionsRepository _repo) : Controller
    {
        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllPrescription());
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ViewBag.action = "create";
            ViewData["MedicineId"] = new SelectList(
                _context.Medicines.Where(m => m.IsDeleted == false), "Id", "Name");
            return View();
        }

        // POST: Prescriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prescription prescription)
        {
            ViewBag.action = "create";

            if (prescription == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _repo.CreatePrescription(prescription);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineId"] = new SelectList(
                _context.Medicines.Where(m => m.IsDeleted == false), "Id", "Name", 
                prescription.MedicineId);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.action = "edit";

            if (id <= 0)
                return NotFound();

            var prescription = await _repo.GetByIdPrescription(id);
            if (prescription == null)
                return NotFound();

            ViewData["MedicineId"] = new SelectList(
                _context.Medicines.Where(m => m.IsDeleted == false), "Id", "Name",
                prescription.MedicineId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prescription prescription)
        {
            ViewBag.action = "edit";

            if (id != prescription.Id || id <= 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var update = await _repo.EditPrescription(id, prescription);
                    if (!update)
                        return NotFound();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.IsPrescriptionExists(id);
                    if (!check)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineId"] = new SelectList(
                _context.Medicines.Where(m => m.IsDeleted == false), "Id", "Name",
                prescription.MedicineId);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var prescription = await _repo.DeletePrescription(id);
            if (!prescription)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Retrieve(int id)
        {
            if (id <= 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var retrieve = await _repo.RetrievePrescription(id);
                    if (!retrieve)
                        return NotFound();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.IsPrescriptionExists(id);
                    if (!check)
                        return NotFound();
                    else
                        throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
