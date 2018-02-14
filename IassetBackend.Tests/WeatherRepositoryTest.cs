
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IassetBackend.Data.DAL;
using IassetBackend.Data.Models;
using System.Linq;

namespace IassetBackend.Tests
{
    [TestClass]
    public class WeatherRepositoryTest
    {
        [TestMethod]
        public void GetCountry_Test()
        {
            // Arrange
            IWeatherRepository weatherRepository = new WeatherRepository();

            // Act
            Country country = weatherRepository.GetCountry("Australia");

            // Assert
            Assert.AreEqual("Australia", country.Name);
            Assert.IsTrue(country.Cities.Where(c => c.Name.Equals("Sydney Airport")).Count() > 0);
        }
        
        public void GetCountry_ForFakeCountry_ReturnsNull_Test()
        {
            // Arrange
            IWeatherRepository weatherRepository = new WeatherRepository();

            // Act
            Country country = weatherRepository.GetCountry("Moon");

            // Assert
            Assert.IsNull(country);
        }

        [TestMethod]
        public void GetWeather_Test()
        {
            // Arrange
            IWeatherRepository weatherRepository = new WeatherRepository();

            // Act
            Weather weather = weatherRepository.GetWeather("Australia", "Sydney Airport");

            // Assert
            Assert.AreEqual("Australia", weather.Country.Name);
            Assert.AreEqual("Sydney Airport", weather.City.Name);            
            Assert.AreEqual("Sydney /Australia 28-34N 077-07E 233M", weather.Location);           
        }
    }
}
