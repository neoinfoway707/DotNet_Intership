using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day_8_CodeFirst_Relationships_in_MVC.Data;
using Day_8_CodeFirst_Relationships_in_MVC.Models;

namespace Day_8_CodeFirst_Relationships_in_MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Books.Include(b => b.Author).Include(b=>b.Categories);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.action = "create";
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["Categories"] = new MultiSelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, int[] selectedCategories)
        {
            ViewBag.action = "create";

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

                if (selectedCategories != null && selectedCategories.Length > 0)
                {
                    var savedBook = await _context.Books
                        .Include(b => b.Categories)
                        .FirstOrDefaultAsync(b => b.Id == book.Id);

                    savedBook.Categories = _context.Categories
                        .Where(c => selectedCategories.Contains(c.Id))
                        .ToList();

                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            ViewData["Categories"] = new MultiSelectList(_context.Categories, "Id", "Name");
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.action = "Edit";

            if (id == null)
                return NotFound();

            var book = await _context.Books
                .Include(b => b.Categories)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return NotFound();
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            ViewData["Categories"] = new MultiSelectList(_context.Categories, "Id", "Name",
                book.Categories.Select(c => c.Id));
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book, int[] selectedCategories)
        {
            ViewBag.action = "Edit";

            if (id != book.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();

                    var savedBook = await _context.Books
                        .Include(b => b.Categories)
                        .FirstOrDefaultAsync(b => b.Id == book.Id);

                    savedBook.Categories = _context.Categories
                        .Where(c => selectedCategories.Contains(c.Id))
                        .ToList();

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books.FindAsync(id);
            if (book != null)
                _context.Books.Remove(book);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
