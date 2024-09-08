using CampusConnect.Models.Interfaces;
using CampusConnect.Models.Models.ViewModels;
using CampusConnect.Web.Data;
using CampusConnect.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;

        public AccountController(ApplicationDbContext context)
        {
             _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public  void Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
               
                var user = new User()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    UserType = model.UserType,
                    Email = model.Email,
                    Password = model.Password
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                
            }

            return; 

        }
    }
}
