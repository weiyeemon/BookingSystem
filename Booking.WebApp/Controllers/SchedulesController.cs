using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Model;
using Booking.WebApp.Core;

namespace Booking.WebApp.Controllers {
    public class SchedulesController : Controller
    {
        private readonly BookingDBContext _context;

        public SchedulesController(BookingDBContext context)
        {
            _context = context;
        }

        
        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            string userId = String.Empty;
            var cookie = Request.Cookies.TryGetValue(Constants.UserIdCookie, out userId);
            var bookingDBContext = _context.Schedules
                .Include(s => s.Package)
                .Include(s => s.User)
                .Where(s => s.UserId == int.Parse(userId));
            return View(await bookingDBContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Package)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        private bool ScheduleExists(int id)
        {
          return (_context.Schedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
