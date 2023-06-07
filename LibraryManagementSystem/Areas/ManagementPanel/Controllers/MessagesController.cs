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
    public class MessagesController : Controller
    {
        private readonly LibraryManagementDbContext _context = new LibraryManagementDbContext();

        // GET: ManagementPanel/Messages
        public async Task<IActionResult> Index()
        {
              return View(await _context.Messages.ToListAsync());
        }

        // GET: ManagementPanel/Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }
    }
}
