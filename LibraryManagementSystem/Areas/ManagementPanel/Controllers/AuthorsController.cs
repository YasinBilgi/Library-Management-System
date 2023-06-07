using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using System.Security.Cryptography;
using Microsoft.Extensions.Hosting;
using LibraryManagementSystem.Areas.ManagementPanel.Helpers;
using NuGet.Configuration;
using System.Drawing;
using LibraryManagementSystem.Entites.Models;

namespace LibraryManagementSystem.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class AuthorsController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public AuthorsController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // GET: ManagementPanel/Authors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Authors.ToListAsync());
        }

        // GET: ManagementPanel/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                author.İsActive = true;
                author.RegisterDate = DateTime.Now;
                if (img != null)
                {
                    author.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }

                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: ManagementPanel/Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: ManagementPanel/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author, IFormFile img)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Author editAuthor = await _context.Authors.FindAsync(author.Id);
                    editAuthor.FullName = editAuthor.FullName;
                    editAuthor.BirthDate = editAuthor.BirthDate;
                    editAuthor.Biography = editAuthor.Biography;
                    editAuthor.İsActive = author.İsActive;

                    if (img != null)
                    {
                        editAuthor.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }


        // GET: ManagementPanel/Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
    }
}
