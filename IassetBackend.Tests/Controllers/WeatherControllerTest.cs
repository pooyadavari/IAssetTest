using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IassetBackend.Controllers;
using IassetBackend.Data.DAL;
using IassetBackend.Data.Models;
using Moq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace IassetBackend.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTest
    {
        [TestMethod]
        public void GetCountry_Returns_SameCountryAndCities()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();
            mockRepository.Setup(x => x.GetCountry("Australia"))
                .Returns(new Country
                {
                    Name = "Australia",
                    Cities = new List<City>
                    {
                        new City
                        {
                            Name = "Sydney"
                        }
                    }
                });

            var controller = new WeatherController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetCountry("Australia");
            var contentResult = actionResult as OkNegotiatedContentResult<Country>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Australia", contentResult.Content.Name);
            Assert.AreEqual("Sydney", contentResult.Content.Cities[0].Name);
        }
        [TestMethod]
        public void GetCountry_Returns_NotFound()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();

            var controller = new WeatherController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetCountry("Moon");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetWeather_Test()
        {
            // Arrange
            City city = new City { Name = "Sydney" };
            Country country = new Country
            {
                Name = "Australia",
                Cities = new List<City> { city }
            };

            var mockRepository = new Mock<IWeatherRepository>();
            mockRepository.Setup(x => x.GetWeather("Australia", "Sydney"))
                .Returns(new Weather
                {
                    City = city,
                    Country = country,
                    Location = "Sydney /Australia 28-34N 077-07E 233M",
                    Temperature = "51 F (11 C)"
                });

            var controller = new WeatherController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetWeather("Australia", "Sydney");
            var contentResult = actionResult as OkNegotiatedContentResult<Weather>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreSame(city, contentResult.Content.City);
            Assert.AreSame(country, contentResult.Content.Country);
            Assert.AreEqual("Sydney /Australia 28-34N 077-07E 233M", contentResult.Content.Location);
            Assert.AreEqual("51 F (11 C)", contentResult.Content.Temperature);
        }

        [TestMethod]
        public void GetWeather_Returns_NotFound()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();

            var controller = new WeatherController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetWeather("Moon", "Star");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
