using GatewayAPI.Models;
using GatewayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageUser<UserDTO> _manageUser;

        public UserController(IManageUser<UserDTO> manageUser)
        {
            _manageUser = manageUser;
        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO user)
        {
            var myUser = await _manageUser.Register(user);

            if (myUser == null)
                return BadRequest("Could not register user");
            return Ok(myUser);
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO user)
        {
            var myUser = await _manageUser.Login(user);

            if (myUser == null)
                return BadRequest("Invalid Username or Password");
            return Ok(myUser);
        }
    }
}
