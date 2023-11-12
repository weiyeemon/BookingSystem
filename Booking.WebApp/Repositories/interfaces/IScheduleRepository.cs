using Booking.Model;
using Booking.WebApp.ViewModels;

namespace Booking.WebApp.Repositories.interfaces {
    public interface IScheduleRepository {
        Task CreateSchedule(CreateScheduleVM createScheduleVM);
        Task CancelBooking(int id);
        List<ScheduleVM> BookingList(int userId);
    }
}
