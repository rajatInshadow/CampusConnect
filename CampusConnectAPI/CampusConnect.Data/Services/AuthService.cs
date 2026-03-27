using CampusConnect.Application.Interfaces;
using CampusConnect.Application.Security;
using CampusConnect.Model;
using CampusConnect.Model.Dtos.Auth;
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

        public async Task<UserDto> SignUp(UserDto user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                Email = user.Email

            };
                await _dbConnection.User.AddAsync(newUser);
            await _dbConnection.SaveChangesAsync();

            return user;
        }
    }
}
