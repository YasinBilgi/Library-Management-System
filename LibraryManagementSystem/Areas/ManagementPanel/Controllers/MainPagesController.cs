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
    public class MainPagesController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

        

        // GET: ManagementPanel/MainPages
        public async Task<IActionResult> Index()
        {
              return View(await _context.MainPages.FirstOrDefaultAsync());
        }

        
        // GET: ManagementPanel/MainPages/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.MainPages == null)
            {
                return NotFound();
            }

            var mainPage = await _context.MainPages.FindAsync(id);
            if (mainPage == null)
            {
                return NotFound();
            }
            return View(mainPage);
        }

        // POST: ManagementPanel/MainPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainPage mainPage)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MainPage editContact = await _context.MainPages.FindAsync(mainPage.Id);
                    editContact.SliderSubtitle1 = mainPage.SliderSubtitle1;
                    editContact.SliderSubtitle2 = mainPage.SliderSubtitle2;
                    editContact.SliderSubtitle3 = mainPage.SliderSubtitle3;
                    editContact.ServiceDescription1 = mainPage.ServiceDescription1;
                    editContact.ServiceDescription2 = mainPage.ServiceDescription2;
                    editContact.ServiceDescription3 = mainPage.ServiceDescription3;
                    editContact.ServiceTitle1 = mainPage.ServiceTitle1;
                    editContact.ServiceTitle2 = mainPage.ServiceTitle2;
                    editContact.ServiceTitle3 = mainPage.ServiceTitle3;
                    editContact.SliderTitle1 = mainPage.SliderTitle1;
                    editContact.SliderTite2 = mainPage.SliderTite2;
                    editContact.SliderTitle3 = mainPage.SliderTitle3;
                    editContact.SliderİmageUrl1 = mainPage.SliderİmageUrl1;
                    editContact.SliderİmageUrl2 = mainPage.SliderİmageUrl2;
                    editContact.SliderİmageUrl3 = mainPage.SliderİmageUrl3;
                    editContact.LastSavedTitle = mainPage.LastSavedTitle;
                    _context.Update(mainPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mainPage);
        }
    }
}
