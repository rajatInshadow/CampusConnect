using CampusConnect.Models.Models.Entities;
using CampusConnect.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Models.Interfaces
{
    public interface IAccountService
    {
        public bool ResgisterUser(RegisterViewModel model);
        public User LoginUser(LogInViewModel model);
    }
}
