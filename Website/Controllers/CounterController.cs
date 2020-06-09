using Business.Services.Interfaces;
using Contract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Website.ControllerBodyModels;

namespace Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class CounterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IServerService _serverService;
        private readonly ICounterService _counterService;
        private readonly ITimeSeriesService _timeSeriesService;
        public CounterController(IUserService userService,
            ICounterService counterService, 
            ITimeSeriesService timeSeriesService,
            IServerService serverService)
        {
            _userService = userService;
            _counterService = counterService;
            _timeSeriesService = timeSeriesService;
            _serverService = serverService;
        }

        [HttpPost("uploadData")]
        public async Task<IActionResult> UploadData([FromBody] CounterUploadModel counter)
        {
            var user = _userService.GetUserFromClaims(User.Claims);
            try
            {
                await _counterService.UploadData(counter, user.Id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("getPrediction")]
        public async Task<IActionResult> GetPrediction([FromBody] PredictionOptions options)
        {
            var user = _userService.GetUserFromClaims(User.Claims);
            try
            {
                if (!await _serverService.IsServerBelongsToUser(user.Id, options.ServerId))
                {
                    return Forbid();
                }

                var predictions = await _timeSeriesService.GetDataForCounter(options.Options, options.CounterName,
                    options.ServerId, options.BeginDate, options.EndDate);
                return Ok(predictions);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}