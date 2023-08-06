using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public AccountController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            User user = _databaseContext.Users.SingleOrDefault(x => x.UserName == model.UserName && x.PassWord == model.Password);

            if(user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("UserName", user.UserName.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "UserName or Password is incorrect.");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
           if(_databaseContext.Users.Any(x => x.UserName == model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "UserName is already exists.");
                return View(model);
            }

           if(ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = model.UserName,
                    PassWord = model.Password,
                };

                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login") ;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
