using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
