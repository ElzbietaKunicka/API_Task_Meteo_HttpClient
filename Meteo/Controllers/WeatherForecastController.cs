using Meteo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meteo.Controllers
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
        private readonly IMeteoHttpClient _meteoHttpClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMeteoHttpClient meteoHttpClient)
        {
            _logger = logger;
            _meteoHttpClient = meteoHttpClient;
        }

        [HttpGet("station")]
        public async Task<StationResponse> GetStation()
        {
            var station = await _meteoHttpClient.GetStation();
            return station;
        }

        [HttpGet("places/{placeCode}/forecasts")]
        public async Task<Forecast[]> GetStationByCode(string placeCode)
        {
            var station = await _meteoHttpClient.GetStationByPlaceCode(placeCode);
            return station;
        }

        [HttpGet("places/{placeCode}/forecasts/{forecastType}")]
        public async Task<TypeOfForecast> GetStationByType(string placeCode, string forecastType)
        {
            var station = await _meteoHttpClient.GetStationByForecastType(placeCode, forecastType);
            return station;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}