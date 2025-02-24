using HMSAPI.Service.TblUser;
using Microsoft.AspNetCore.Mvc;

namespace HMSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITblUser _serviceTblUser;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITblUser serviceTblUser)//, ITblUser tblUser)
        {
            _logger = logger;
            _serviceTblUser = serviceTblUser;
            // _serviceTblUser= tblUser;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "ValidateCredential")]
        //public IActionResult ValidateCredential(string email, string password)
        //{
        //    return Ok();
        //    return Ok(_serviceTblUser.validateCredential(email, password));
        //}

        [HttpGet("[action]")]
        public IActionResult validateCredential(string email, string password)
        {
            return Ok(_serviceTblUser.validateCredential(email, password));
        }
    }
}
