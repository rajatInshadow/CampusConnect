using CampusConnect.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models.Models;
using CampusConnect.Models.Models.ViewModels;
using CampusConnect.Data;
using CampusConnect.Models.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace CampusConnect.Application.Services
{
    public class AccountServices : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ResgisterUser(RegisterViewModel model)
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

            
            return ;
        }
    }
}
