using Booking.Model;
using Booking.WebApp.Repositories.interfaces;
using Booking.WebApp.ViewModels;

namespace Booking.WebApp.Repositories
{
    public class UserRepository : IUserRepository {
        private readonly BookingDBContext db;

        public UserRepository(BookingDBContext context) {
            db = context;
        }

        public Task CreateUser(UserVM userVM) {
            var existingUser = this.db.Users.FirstOrDefault(u => u.Email == userVM.Email);
            if (existingUser == null) {
                User newUser = new User {
                    Email = userVM.Email,
                    Password = userVM.Password,
                    TotalCredit = 10
                };
                this.db.Users.Add(newUser);
                this.db.SaveChanges();
            }
            return null;
        }

        public bool ValidateUser(UserVM userVM) {
            return this.db.Users.Any(u => u.Email.Equals(userVM.Email) && u.Password.Equals(userVM.Password));
        }
    }
}
