using System.Threading.Tasks;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.ControllerBodyModels;

namespace Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _serverService;
        private readonly IUserService _userService;
        public ServerController(IServerService serverService,
            IUserService userService)
        {
            _userService = userService;
            _serverService = serverService;
        }

        [Authorize]
        [HttpPost("addServer")]
        public async Task<IActionResult> AddServer([FromBody] ServerInfo serverInfo)
        {
            var userId = _userService.GetUserFromClaims(User.Claims).Id;

            var server = await _serverService.AddServer(serverInfo.ServerName, serverInfo.IpAddress, userId);

            return server != null
                ? (IActionResult) Ok(server)
                : BadRequest();
        }

        [Authorize]
        [HttpGet("getServersList")]
        public async Task<IActionResult> GetServers()
        {
            var userId = _userService.GetUserFromClaims(User.Claims).Id;

            var server = await _serverService.GetServersForUser(userId);

            return server != null
                ? (IActionResult)Ok(server)
                : BadRequest();
        }
    }
}