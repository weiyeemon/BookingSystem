using Booking.Model;
using Booking.WebApp.Repositories.interfaces;
using Booking.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Booking.WebApp.Repositories {
    public class ScheduleRepository : IScheduleRepository {
        private readonly BookingDBContext db;

        public ScheduleRepository(BookingDBContext context) {
            db = context;
        }

        public async Task CreateSchedule(CreateScheduleVM createScheduleVM) {
            var package = await db.Packages.Include(p => p.Users).FirstAsync(p => p.Id == createScheduleVM.PackageId);
            var user = await db.Users.FirstAsync(u => u.Id == createScheduleVM.UserId);
            if (user.TotalCredit > package.Credit) {
                user.TotalCredit = user.TotalCredit - package.Credit;
                var newSchedule = new Schedule {
                    UserId = user.Id,
                    PackageId = package.Id,
                    StartTime = DateTime.Now,

                };
                if (package.Users.Count > 5)
                    newSchedule.ScheduleType = ScheduleType.WaitList;
                newSchedule.ScheduleType = ScheduleType.Book;
                db.Schedules.Add(newSchedule);
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task CancelBooking(int id) {
            var schedule = await db.Schedules.Include(s => s.Package).FirstAsync(u => u.Id == id);
            var user = await db.Users.FirstAsync(u => u.Id == schedule.Id);
            if (schedule != null) {
                var removePackage = schedule.Package;
                TimeSpan timeDifference = schedule.StartTime - DateTime.Now;

                if (timeDifference.TotalHours >= 4) {
                    user.TotalCredit += removePackage.Credit;
                }
                user.Packages.Remove(removePackage);
                db.Schedules.Remove(schedule);
                await db.SaveChangesAsync();
            }
        }
        public List<ScheduleVM> BookingList(int userId) {
            return db.Schedules.Include(s => s.Package)
                   .Include(s => s.User)
                   .Where(s => s.UserId == userId)
                   .Select(x => new ScheduleVM {
                       PackageName = x.Package.Name,
                       StartTime = x.StartTime
                   }).ToList();
        }
    }

}
