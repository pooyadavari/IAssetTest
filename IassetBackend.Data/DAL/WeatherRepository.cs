
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using IassetBackend.Data.Models;
using IassetBackend.Data.Models.ServiceModels;

namespace IassetBackend.Data.DAL
{
    public class WeatherRepository: IWeatherRepository
    {
        /// <summary>
        /// Get country and cities by country name
        /// </summary>
        public Country GetCountry(string countryName)
        {
            //Get from service
            IassetBackend.Data.GlobalWeatherService.GlobalWeather WeatherService = new IassetBackend.Data.GlobalWeatherService.GlobalWeather();
            string response = WeatherService.GetCitiesByCountry(countryName); //Australia

            //Deseriallize
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CitiesOfCountryResult));
            CitiesOfCountryResult countryCitiesResult = xmlSerializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(response))) as CitiesOfCountryResult;

            //Mapping
            var country = new Country
            {
                Name = countryCitiesResult.CitiesOfCountry
                    .Select(t => t.Country).Distinct().FirstOrDefault(),
                Cities = countryCitiesResult.CitiesOfCountry
                    .Select(t => new City { Name = t.City }).ToList<City>()
            };
            
            return country;
        }

        /// <summary>
        /// Get weather by country name and city name
        /// </summary>
        public Weather GetWeather(string countryName, string cityName)
        {
            // Get from service
            //IassetBackend.Data.GlobalWeatherService.GlobalWeather WeatherService = new IassetBackend.Data.GlobalWeatherService.GlobalWeather();
            //string response = WeatherService.GetWeather(cityName,countryName);

            // Get mocked data ***Service doesn't return any data***
            string response = GetWeatherMockedData();

            //Deseriallize
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeatherResult));
            WeatherResult weatherResult = xmlSerializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(response))) as WeatherResult;
            var weather = new Weather();
                        
            //Mapping
            weather.Country = new Country { Name = countryName };
            weather.City = new City { Name = cityName };
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WeatherResult, Weather>());
            IMapper mapper = config.CreateMapper();            
            var dest = mapper.Map<WeatherResult, Weather>(weatherResult, weather);
            
            return weather;            
        }

        /// <summary>
        /// Weather mocked data
        /// </summary>        
        private string GetWeatherMockedData()
        {
            return "<CurrentWeather>\n    <Location>Sydney /Australia 28-34N 077-07E 233M</Location>\n    <Time>Jan 19, 2018 - 09:00 AM EST / 2018.01.19 1400 UTC</Time>\n    <Wind> from the NW (320 degrees) at 7 MPH (6 KT):0</Wind>\n    <Visibility> 1 mile(s):0</Visibility>\n    <SkyConditions> mostly cloudy</SkyConditions>\n    <Temperature> 51 F (11 C)</Temperature>\n    <DewPoint> 46 F (8 C)</DewPoint>\n    <RelativeHumidity> 81%</RelativeHumidity>\n    <Pressure> 30.03 in. Hg (1017 hPa)</Pressure>\n    <Status>Success</Status>\n    </CurrentWeather>";
        }
    }
}