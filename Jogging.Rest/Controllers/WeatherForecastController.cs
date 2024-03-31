using AutoMapper;
using Jogging.Domain;
using Jogging.Domain.Models;
using Jogging.Rest.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jogging.Rest.Controllers
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
        private readonly IMapper _mapper;
        /*
        private readonly Supabase.Client _supabaseClient; // Inject Supabase client
        */

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper/*,
            Supabase.Client supabaseClient*/)
        {
            _logger = logger;
            _mapper = mapper;
            /*_supabaseClient = supabaseClient;*/
        }

        [HttpGet(Name = "GetWeatherForecast")]
        async public Task<ActionResult<IEnumerable<WeatherForecastDTO>>> Get()
        {
            try
            {
                // TEST INSERT FOR SUPABASE
                /*var model = new City
                {
                    Name = "The Shire",
                    CountryId = 554
                };

                await _supabaseClient.From<City>().Insert(model);*/
                var weatherForeCastDto = new WeatherForecastDTO()
                    { TemperatureC = 6, Date = DateOnly.MinValue, Summary = "test" };
                return Ok(_mapper.Map<WeatherForecast>(weatherForeCastDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving weather forecasts.");
                return StatusCode(500); // Return 500 Internal Server Error in case of an exception
            }
        }
    }
}