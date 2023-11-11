using Booking.WebApp.ViewModels;

namespace Booking.WebApp.Repositories.interfaces
{
    public interface IUserRepository
    {
        bool ValidateUser(UserVM userVM);
        Task CreateUser(UserVM createUserVM);
    }
}
