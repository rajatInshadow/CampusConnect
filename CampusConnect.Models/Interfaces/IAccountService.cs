using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Models.Interfaces
{
    public interface IAccountService
    {
        Task<ActionResult> ResgisterUser();
    }
}
