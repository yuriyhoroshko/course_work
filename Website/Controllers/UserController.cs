using System.Linq;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Website.ControllerBodyModels;

namespace Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenFactory _tokenFactory;

        public UserController(IUserService userService, TokenFactory tokenFactory)
        {
            _userService = userService;
            _tokenFactory = tokenFactory;
        }

        [EnableCors("All")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCredentials userCredentials)
        {
            var user = await _userService.RegisterUser(userCredentials.UserName, userCredentials.Password);

            string token = string.Empty;

            if(user != null)
                 token = _tokenFactory.CreateToken(user);

            return user != null ? (IActionResult)Ok(new LoggedUserDto{UserName = user.UserName, Token = token}) : BadRequest();
        }

        [EnableCors("All")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentials userCredentials)
        {
            var loggedUser = await _userService.LoginUser(userCredentials.UserName, userCredentials.Password);
            var token = string.Empty;

            if (loggedUser != null)
                token = _tokenFactory.CreateToken(loggedUser);
            

            return loggedUser != null
                ? (IActionResult) Ok(new LoggedUserDto {UserName = loggedUser.UserName, Token = token})
                : BadRequest();
        }
    }
}