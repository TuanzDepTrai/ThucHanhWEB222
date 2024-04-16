using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucHanhWEB222.Data;
using ThucHanhWEB222.Models;

namespace ThucHanhWEB222.Controllers
{
    public class BookController:Controller
    {

        private readonly MyDbContext _context;

        public BookController(MyDbContext context)
        {
            _context = context;
        }

        // GET: /Book
        public IActionResult Index()
        {
            var books = _context.Book.ToList();
            return View(books);
        }

        // GET: /Book/Details/5
        public IActionResult Details(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

      
        public IActionResult Edit(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Books book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Book.Any(b => b.BookID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: /Book/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookID == id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
