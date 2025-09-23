using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserModel _userDetails;
        public WeatherForecastController(IAuthentication authentication, ILogger<WeatherForecastController> logger, IUserModel userModel)
        {
            _authentication = authentication;
            _logger = logger;
            _userDetails = userModel;

        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet(Name = "GetWeatherForecast")]
        [AllowAnonymous]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var valid = false;
        //    string _Accesstokaen = HttpContext.Request.Headers.Authorization;
        //    if (_Accesstokaen == null)
        //    {
        //        _Accesstokaen = _authentication.GenerateJwtToken(null, 60);
        //    }
        //    else
        //    {
        //        valid = _authentication.ValidateTokenCLaim(_Accesstokaen);
        //    }


        //    if (valid)
        //    {
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
        //    // Return an empty array instead of null to avoid runtime errors
        //    return Array.Empty<WeatherForecast>();
        //}
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _userDetails.GetUserDetails();
            //return Ok(users);
        }


        // Example of adding another API endpoint
        [HttpGet("today", Name = "GetTodayWeather")]
        [AllowAnonymous]
        public ActionResult<WeatherForecast> GetToday()
        {
          // IEnumerable<UserModel> users =  _userDetails.GetUserDetails();
            return Ok();
            
            //return Unauthorized();
        }

        //[HttpGet(Name = "GetUserDetails")]
        //[AllowAnonymous]
        //public ActionResult<WeatherForecast> GetUserDetails()
        //{
        //    IEnumerable<UserModel> users = _userDetails.GetUserDetails();
        //    return Ok();

        //    //return Unauthorized();
        //}
    }
}
