using CampusConnect.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models.Models;
using CampusConnect.Web.Models.NewFolder2;

namespace CampusConnect.Application.Services
{
    public class AccountServices : IAccountService
    {
        public AccountServices() { }

        public  Task<ActionResult> ResgisterUser(RegisterViewModel model)
        {
            return View(model);
        }
    }
}
