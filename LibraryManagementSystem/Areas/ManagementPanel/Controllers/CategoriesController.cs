using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Entites.Models;

namespace LibraryManagementSystem.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class CategoriesController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();


        // GET: ManagementPanel/Categories
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categories.ToListAsync());
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
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.İsActive = true;
                category.RegisterDate = DateTime.Now;
                _context.Add(category);

                return RedirectToAction("Index", "Categories");
            }
            return View(category);
        }

        // GET: ManagementPanel/Categories/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: ManagementPanel/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Name,İsActive,RegisterDate")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        private bool CategoryExists(byte id)
        {
          return _context.Categories.Any(e => e.Id == id);
        }
    }
}
