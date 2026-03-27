using CampusConnect.Model.Dtos.Auth;

namespace CampusConnect.Application.Interfaces
{
    public interface IAuthService
    {

        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> SignUp(UserDto user);
    }
}
