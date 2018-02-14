using IassetBackend.Data.DAL;
using IassetBackend.Data.Models;
using System.Linq;
using System.Web.Http;

namespace IassetBackend.Controllers
{
    [RoutePrefix("api")]
    public class WeatherController : ApiController
    {
        // Dependency injection
        private IWeatherRepository _weatherRepository;
        public WeatherController(IWeatherRepository weatherRepository)
        {
            this._weatherRepository = weatherRepository;
        }

        /// <summary>
        /// Get country by country name
        /// </summary>        
        /// <example>http://localhost:7474/api/country/australia</example>
        [HttpGet]
        [Route("country/{countryName}")]
        public IHttpActionResult GetCountry([FromUri]string countryName)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(countryName))
                return BadRequest("Country name shouldn't be empty");

            // Get country from repository
            var country = _weatherRepository.GetCountry(countryName);

            // Response
            if (country == null) return NotFound();
            if (country.Cities.Count() == 0) return NotFound();

            return Ok(country);                       
        }

        /// <summary>
        /// Get weather by country name and city name
        /// </summary>        
        /// <example>http://localhost:7474/api/weather/australia/sydney</example>
        [HttpGet]
        [Route("weather/{countryName}/{cityName}")]
        public IHttpActionResult GetWeather([FromUri]string countryName, [FromUri]string cityName)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(countryName))
                return BadRequest("country name shouldn't be empty");

            if (string.IsNullOrWhiteSpace(cityName))
                return BadRequest("city name shouldn't be empty");

            // Get weather from repository
            Weather weather = _weatherRepository.GetWeather(countryName, cityName);

            // Response
            if (weather == null) return NotFound();
            return Ok(weather);                            
        }
    }
}
