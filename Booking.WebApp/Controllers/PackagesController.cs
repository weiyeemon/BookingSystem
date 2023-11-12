using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Model;
using Microsoft.AspNetCore.Authorization;
using Booking.WebApp.ViewModels;
using Booking.WebApp.Core;

namespace Booking.WebApp.Controllers {
    public class PackagesController : Controller
    {
        private readonly BookingDBContext _context;

        public PackagesController(BookingDBContext context)
        {
            _context = context;
        }
        //[Authorize]
        // GET: Packages
        public async Task<IActionResult> Index()
        {
              return _context.Packages != null ? 
                          View(await _context.Packages.ToListAsync()) :
                          Problem("Entity set 'BookingDBContext.Packages'  is null.");
        }
       
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null || _context.Packages == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (ModelState.IsValid)
            {
                string userId = String.Empty;
                var cookie = Request.Cookies.TryGetValue(Constants.UserIdCookie, out userId);
                try
                {
                    _context.Update(package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(id))
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
            return View(package);
        }

        private bool PackageExists(int id)
        {
          return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
