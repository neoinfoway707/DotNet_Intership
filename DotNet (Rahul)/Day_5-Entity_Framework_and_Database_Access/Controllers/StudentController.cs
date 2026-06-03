using Day_5_Entity_Framework_and_Database_Access.Repositories;
using Day_5_Entity_Framework_Database_Access.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_5_Entity_Framework_and_Database_Access.Controllers
{
    public class StudentController(IStudentRepository _repo) : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            List<Student> stud = await _repo.GetAllStudents();
            return View("Index",stud);
        }
        
        // GET: StudentController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.action = "Create";
            return View("Create");
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            ViewBag.action = "Create";
            if (!ModelState.IsValid)
                return View(student);
            try
            {
                await _repo.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(student);
            }
        }

        [HttpGet]
        // GET: StudentController/Edit/5
        public async Task<ActionResult> Update(int id)
        {
            ViewBag.action = "Update";
            var student = await _repo.GetById(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Student student)
        {
            ViewBag.action = "Update";
            try
            {
                var update = await _repo.UpdateStudent(id, student);
                if (update)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                return View(student);
            }
        }

        [HttpGet]
        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var delete = await _repo.DeleteStudent(id);
                if (delete)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
