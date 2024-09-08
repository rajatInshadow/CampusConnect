using CampusConnect.Data;
using CampusConnect.Models.Interfaces;
using CampusConnect.Models.Models.Entities;
using CampusConnect.Models.Models.ViewModels;
using CampusConnect.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public  void Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                  _accountService.ResgisterUser(model);
                
            }

            return ; 

        }
    }
}
