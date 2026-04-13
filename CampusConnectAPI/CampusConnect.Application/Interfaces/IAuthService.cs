using CampusConnect.Model;
using CampusConnect.Model.Dtos.Auth;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface IAuthService
    {

        Task<IEnumerable<UserDto>> GetUsers();
        Task<ApiResponse<User>> SignUp(UserDto user);
        Task<LoginResponse> SignIn(LoginDto loginDto);
        Task<ApiResponse<User>> SignOut(string email);
    }
}
