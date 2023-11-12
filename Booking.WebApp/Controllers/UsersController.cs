using Booking.WebApp.Core;
using Booking.WebApp.Repositories.interfaces;
using Booking.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Constants = Booking.WebApp.Core.Constants;

namespace Booking.WebApp.Controllers
{
    public class UsersController : Controller {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UsersController(IUserRepository userRepository, IConfiguration configuration) {
            _userRepository = userRepository;
            _config = configuration;
        }
    
        [AllowAnonymous]
        public IActionResult Login() {
            return View();
        }

        [HttpPost, ActionName("Login")]
        [AllowAnonymous]
        public IActionResult Login(UserVM userVM) {
            if (this._userRepository.ValidateUser(userVM)) {
                //var jwtToken = GenerateJwtToken(userVM);
                //return RedirectToAction("Index", "Packages"  , new { Token= jwtToken });
                int id = _userRepository.GetUserByEmail(userVM.Email).Id;
                AddUserIdInCookie(id);
                 return RedirectToAction("Index", "Packages");
            }
            return View();
        }
        private void AddUserIdInCookie(int id) {
            Response.Cookies.Append(Constants.UserIdCookie, id.ToString(), new CookieOptions() {
                Expires = DateTimeOffset.UtcNow.AddDays(1),
            });
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

        //private string GenerateJwtToken(UserVM user) {
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim("Email", user.Email),
        //    };
        //    var token = new JwtSecurityToken(
        //        _config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}
    }
}
