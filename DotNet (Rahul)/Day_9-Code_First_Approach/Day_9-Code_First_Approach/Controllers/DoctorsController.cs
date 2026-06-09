using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day_9_Code_First_Approach.Data;
using Day_9_Code_First_Approach.Models;
using Day_9_Code_First_Approach.Repositories;

namespace Day_9_Code_First_Approach.Controllers
{
    public class DoctorsController(IDoctorRepository _repo) : Controller
    {
        
        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetallDoctors());
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (doctor == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _repo.Create(doctor);
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }
    }
}
