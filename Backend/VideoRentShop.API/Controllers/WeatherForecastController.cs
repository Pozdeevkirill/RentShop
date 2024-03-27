using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Models.Identity;

namespace VideoRentShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<User> _userRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            return Ok(_userRepository.List());
        }
    }
}
