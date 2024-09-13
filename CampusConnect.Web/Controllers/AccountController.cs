using CampusConnect.Data;
using CampusConnect.Models.Interfaces;
using CampusConnect.Models.Models.Entities;
using CampusConnect.Models.Models.ViewModels;
using CampusConnect.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace CampusConnect.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;

        public AccountController(ApplicationDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var isValidUser = _accountService.ResgisterUser(model);
                if(isValidUser)
                {
                return RedirectToAction("Login","Account");

                } else
                {
                    return View(model);
                }

            }else
            {
                return View(model);

            }


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.LoginUser(model);
                var isUserFound = (user.Email == model.Email);
                if (isUserFound)
                {
                    var identity = new ClaimsIdentity(new[] { 
                        new Claim(ClaimTypes.Name, model.Email) 
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Username", model.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","Account");
        }
    }
}
