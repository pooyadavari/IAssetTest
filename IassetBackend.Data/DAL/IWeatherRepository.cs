
using IassetBackend.Data.Models;
using System.Linq;

namespace IassetBackend.Data.DAL
{    
    public interface IWeatherRepository
    {
        Country GetCountry(string CountryName);
        Weather GetWeather(string CountryName, string CityName);
    }
}
