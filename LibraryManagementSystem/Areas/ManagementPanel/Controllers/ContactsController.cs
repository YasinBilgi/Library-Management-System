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
    public class ContactsController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

    
        // GET: ManagementPanel/Contacts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contacts.FirstOrDefaultAsync());
        }

        // GET: ManagementPanel/Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: ManagementPanel/Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Contact editContact = await _context.Contacts.FindAsync(contact.Id);
                    editContact.Email = contact.Email;
                    editContact.Subtitle = contact.Subtitle;
                    editContact.Address = contact.Address;
                    editContact.Phone = contact.Phone;
                    editContact.Latitude = contact.Latitude;
                    editContact.Longitude = contact.Longitude;
                    editContact.Title = contact.Title;
                    //_context.Update(editContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
    }
}
