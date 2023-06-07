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
    public class AboutsController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

        
        // GET: ManagementPanel/Abouts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Abouts.FirstOrDefaultAsync());
        }

        // GET: ManagementPanel/Abouts/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: ManagementPanel/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About about)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    About editContact = await _context.Abouts.FindAsync(about.Id);
                    editContact.Title = about.Title;
                    editContact.Subtitle = about.Subtitle;
                    editContact.İmageUrl = about.İmageUrl;
                    editContact.Description = about.Description;
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

    }
}
