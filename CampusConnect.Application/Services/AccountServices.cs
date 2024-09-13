using CampusConnect.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CampusConnect.Models.Models;
using CampusConnect.Models.Models.ViewModels;
using CampusConnect.Data;
using CampusConnect.Models.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using CampusConnect.Application.Utils;


namespace CampusConnect.Application.Services
{
    public class AccountServices : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher _passwordHasher;

        public AccountServices(ApplicationDbContext context, PasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public bool ResgisterUser(RegisterViewModel model)
        {
            var isValidUser = _context.Users.Where(e => e.Email == model.Email).FirstOrDefault();
            if (isValidUser != null)
            {
                var isValid = false;
                return isValid;
            }
            else
            {

                string encryptedPassword = _passwordHasher.EncryptPassword(model.Password);

                var user = new User()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    UserType = model.UserType,
                    Email = model.Email,
                    Password = encryptedPassword
                };

                _context.Users.Add(user);
                _context.SaveChanges();


                return true;
            }
        }

        public User LoginUser(LogInViewModel model)
        {

            var user = _context.Users.Where(e => e.Email == model.Email).FirstOrDefault();
            if (user != null)
            {
                var isValidUser = _passwordHasher.VerifyPassword(model.Password, user.Password);

                if (isValidUser)
                {
                    return user;
                }
                else
                {

                    return null;
                }


            }
            return null;

        }
    }
}
