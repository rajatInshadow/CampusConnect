using CampusConnect.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            context = _context;
        }
        public IActionResult Register()
        {

            return View();
        }
    }
}
