using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day_11_Database_First_Approach.Data;
using Day_11_Database_First_Approach.Models;
using Day_11_Database_First_Approach.Repositories;

namespace Day_11_Database_First_Approach.Controllers
{
    public class MedicinesController(IMedicinesRepository _repo) : Controller
    {

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllMadicines());
        }
        // GET: Medicines/Create
        public IActionResult Create()
        {
            ViewBag.action = "create";
            return View();
        }

        // POST: Medicines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            ViewBag.action = "create";
            if (medicine == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _repo.Create(medicine);
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.action = "edit";

            if (id == 0)
                return NotFound();

            var medicine = await _repo.GetByIdMadicine(id);
            if (medicine == null)
                return NotFound();
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medicine medicine)
        {
            ViewBag.action = "edit";
            if (id != medicine.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var editMedicine = await _repo.Edit(id, medicine);
                    if (!editMedicine)
                        return NotFound();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.IsMedicineExists(id);
                    if (!check)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var isDelete = await _repo.Delete(id);
            if (!isDelete)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Retrive(int id)
        {
            if (id == 0) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var retriev = await _repo.RetriveMadicine(id);
                    if (retriev == null)
                        return BadRequest();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.IsMedicineExists(id);
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
