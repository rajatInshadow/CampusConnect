using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IEnumerable<UserDto>> GetAllUser()
        {

            IEnumerable<UserDto> userList = await _authService.GetUsers();
            return userList;

        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            var newUser = await _authService.SignUp(userDto);
            return Ok(newUser);

        }




    }
}
