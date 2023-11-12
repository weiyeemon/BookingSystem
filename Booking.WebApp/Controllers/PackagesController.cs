using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Model;
using Booking.WebApp.ViewModels;
using Booking.WebApp.Core;
using Booking.WebApp.Repositories.interfaces;

namespace Booking.WebApp.Controllers {
    public class PackagesController : Controller {
        private readonly BookingDBContext _context;
        private readonly IScheduleRepository _scheduleRepository;

        public PackagesController(BookingDBContext context, IScheduleRepository scheduleRepository) {
            _context = context;
            _scheduleRepository = scheduleRepository;
        }
        //[Authorize]
        // GET: Packages
        public async Task<IActionResult> Index() {
            return _context.Packages != null ?
                        View(await _context.Packages.ToListAsync()) :
                        Problem("Entity set 'BookingDBContext.Packages'  is null.");
        }

        public async Task<IActionResult> Book(int? id) {
            if (id == null || _context.Packages == null) {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null) {
                return NotFound();
            }
            return View(package);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int id) {
            var package = await _context.Packages.FindAsync(id);

            string userId = String.Empty;
            var cookie = Request.Cookies.TryGetValue(Constants.UserIdCookie, out userId);
            try {
                var createScheduleVM = new CreateScheduleVM {
                    PackageId = package.Id,
                    UserId = int.Parse(userId)
                };
                await _scheduleRepository.CreateSchedule(createScheduleVM);

                    await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!PackageExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return RedirectToAction("Index", "Schedules");

        }

        private bool PackageExists(int id) {
            return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
