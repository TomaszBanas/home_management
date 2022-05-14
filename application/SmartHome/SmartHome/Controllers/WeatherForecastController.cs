using Microsoft.AspNetCore.Mvc;
using SmartHome.Database;
using SmartHome.Database.Common;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;

namespace SmartHome.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CacheRepository _cacheRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CacheRepository cacheRepository)
        {
            _logger = logger;
            _cacheRepository = cacheRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok(EntityTypes.ToModels());
            //return Ok(await _cacheRepository.GetAllAsync());
        }
    }
}