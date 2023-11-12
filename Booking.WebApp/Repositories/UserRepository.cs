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

        public Task CreateUser(RegisterVM registerVM) {
            var existingUser = this.db.Users.FirstOrDefault(u => u.Email == registerVM.Email);
            if (existingUser == null) {
                User newUser = new User {
                    Email = registerVM.Email,
                    Password = registerVM.Password,
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
        public int GetUserIdByEmail(string email) {
            return this.db.Users.First(u => u.Email == email).Id;
        }
    }
}
