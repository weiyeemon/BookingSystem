using Booking.WebApp.Repositories.interfaces;
using Booking.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                //var jwtToken = GenerateJwtToken(userVM.Email);
                //return RedirectToAction("Index", "Packages"  , new { Token= jwtToken });
                return RedirectToAction("Index", "Packages");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register() {
            return View();
        }

        [HttpPost, ActionName("Register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterVM userVM) {
           this._userRepository.CreateUser(userVM);
            return RedirectToAction("Index", "Packages");
        }
        //private string GenerateJwtToken(string username) {
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes("3be6bcc4c774d569a4af1a1159e82f134ac3b75c108589995dc19c4c47cc623b"); // Replace with your secret key
        //    var tokenDescriptor = new SecurityTokenDescriptor {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //        new Claim(ClaimTypes.Name, username),
        //            // Add additional claims as needed
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(1), // Adjust expiration as needed
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
