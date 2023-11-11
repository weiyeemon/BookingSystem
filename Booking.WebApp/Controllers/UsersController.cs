using Booking.WebApp.Repositories.interfaces;
using Booking.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebApp.Controllers
{
    public class UsersController : Controller {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    
        [AllowAnonymous]
        public IActionResult Login() {
            return View();
        }

        [HttpPost, ActionName("Login")]
        [AllowAnonymous]
        public IActionResult Login(UserVM userVM) {
            if (this._userRepository.ValidateUser(userVM)) {
                return RedirectToAction("Index", "Packages", new { });
            }
            return View();
        }
    }
}
