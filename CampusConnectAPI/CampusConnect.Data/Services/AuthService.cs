using CampusConnect.Application.Interfaces;
using CampusConnect.Application.Security;
using CampusConnect.Model;
using CampusConnect.Model.Dtos.Auth;
using CampusConnect.Model.Enums;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordService _passwordService;
        private readonly DbConnectContext _dbConnection;
        public AuthService(IPasswordService passwordService, DbConnectContext dbConnectContext) {
            _passwordService = passwordService;
            _dbConnection = dbConnectContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {

            IEnumerable<UserDto> listOfUsers = await _dbConnection.User.Select(x => new UserDto
            {
                Role = Model.Enums.UserRoles.User,
                Email = x.Email,
                UserId = x.UserId,
                PasswordHash = x.PasswordHash,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();

            return listOfUsers;
        }

        public async Task<ApiResponse<User>> SignUp(UserDto user)
        {
            User isUserExist = await _dbConnection.User.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (isUserExist != null)
            {
                // Return null or throw an exception, or handle as per your application's error handling policy.
                return new ApiResponse<User>
                {
                    Success = false,
                    Message = "User with this email already exists.",
                    Data = null

                };
            }

            //UserRoles userRole = UserRoles.User;
            string passwordHash = _passwordService.HashPassword(user.PasswordHash);

            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = passwordHash,
                Role = user.Role,
                Email = user.Email
            };

            await _dbConnection.User.AddAsync(newUser);
            await _dbConnection.SaveChangesAsync();

            return new ApiResponse<User>
            {
                Success = true,
                Message = "User created Successfully",
                Data = newUser

            };
        }

    }
}
