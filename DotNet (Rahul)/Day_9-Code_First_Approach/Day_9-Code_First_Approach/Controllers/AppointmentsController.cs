using Day_9_Code_First_Approach.Data;
using Day_9_Code_First_Approach.Models;
using Day_9_Code_First_Approach.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Day_9_Code_First_Approach.Controllers
{
    public class AppointmentsController(IAppointMentRepository _repo,AppDbContext _context) : Controller
    {
        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _repo.GettAllAppoinments();
            return View(appointments);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewBag.action = "Create";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            ViewBag.action = "Create";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");

            if (appointment == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var addAppointment = await _repo.Create(appointment);
                if (addAppointment)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest();
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.action = "Edit";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");

            var appointment = await _repo.Edit(id);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            ViewBag.action = "Edit";

            if (appointment == null)
                return BadRequest();

            if (id != appointment.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var updateAppointment = await _repo.Edit(id,appointment);
                    if (updateAppointment == null)
                        return BadRequest();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = await _repo.GetByIdAppointment(appointment.Id);
                    if (check == null)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var deleteAppointment = await _repo.Delete(id);
            if(!deleteAppointment)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
