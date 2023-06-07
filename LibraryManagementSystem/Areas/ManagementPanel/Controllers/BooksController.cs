using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Areas.ManagementPanel.Helpers;
using Microsoft.Extensions.Hosting;
using LibraryManagementSystem.Areas.ManagementPanel.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using LibraryManagementSystem.Entites.Models;

namespace LibraryManagementSystem.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class BooksController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public BooksController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // GET: ManagementPanel/Books
        public async Task<IActionResult> Index()
        {
            var libraryManagementDbContext = _context.Books.Include(b => b.Category);
            return View(await libraryManagementDbContext.ToListAsync());
        }

        // GET: ManagementPanel/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.İd == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: ManagementPanel/Books/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: ManagementPanel/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book , IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    book.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }
                book.İsActive = true;
                book.RegisterDate = DateTime.Now;

                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // İKİNCİ YOL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(BookViewModel model, IFormFile img)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Book book = new Book();
        //        if (img != null)
        //        {
        //            book.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
        //        }
        //        book.İsActive = true;
        //        book.RegisterDate = DateTime.Now;
        //        book.Name = model.Name; 
        //        book.PublishDate = model.PublishDate;
        //        book.CategoryId = model.CategoryId;
        //        book.Isbn = model.Isbn;
        //        book.NumberPage = model.NumberPage;
        //        book.BookDetail.Stock = model.Stock;
        //        book.BookDetail.Description = model.Description;


        //        _context.Books.Add(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        //    return View(model);
        //}

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // GET: ManagementPanel/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.Include(x => x.BookDetail).Include(x => x.Category).FirstOrDefaultAsync(r => r.İd == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // POST: ManagementPanel/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book, IFormFile img)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Book editBook = await _context.Books.Include(x => x.BookDetail).Include(x => x.Category).FirstOrDefaultAsync(r => r.İd == book.İd);
                    if (img != null)
                    {
                        editBook.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    editBook.Name = book.Name;
                    editBook.NumberPage = book.NumberPage;
                    editBook.PublishDate = book.PublishDate;
                    editBook.Isbn = book.Isbn;
                    editBook.CategoryId = book.CategoryId;
                    editBook.İsActive = book.İsActive;
                    editBook.BookDetail.Stock = book.BookDetail.Stock;
                    editBook.BookDetail.Description = book.BookDetail.Description;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: ManagementPanel/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.İd == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: ManagementPanel/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibraryManagementDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Books.Any(e => e.İd == id);
        }
    }
}
