using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUIForecast.Application.Contract;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;
using TUIForecast.Application.Impl;
using Xunit;

namespace TUIForecast.Application.Test.UnitTests
{
    public class ForecastServiceTests
    {
        private Mock<ICityRequestService> _cityRequestService;
        private Mock<IWeatherRequestService> _weatherRequestService;
        private IForecastService _forecastService;

        private readonly int days = 2;

        public ForecastServiceTests()
        {
            _cityRequestService = new Mock<ICityRequestService>();
            _weatherRequestService = new Mock<IWeatherRequestService>();

        }

        [Fact]
        public async Task GetForecast_GivenRightCitiesAndCoordinates_ReturnsExpectedWeatherResponse()
        {
            // Arrange
            IEnumerable<CityInfo> citiesWeather = new List<CityInfo>()
            {
                new CityInfo()
                {
                    Name = "TestCity1", Latitude = 52.374, Longitude = 4.9
                },
                new CityInfo()
                {
                    Name = "TestCity2", Latitude = 99.999, Longitude = 9.9
                },
            };
            var coordinates1 = new Coordinates(citiesWeather.First().Latitude, citiesWeather.First().Longitude);
            var coordinates2 = new Coordinates(citiesWeather.Last().Latitude, citiesWeather.Last().Longitude);
            IEnumerable<string> nextDaysWeather = new List<string>() { "Rainy", "Cloudy" };

            _cityRequestService.Setup(crs => crs.GetAll()).Returns(Task.FromResult(citiesWeather));
            _weatherRequestService.Setup(wrs => wrs.GetWeather(coordinates1, days)).Returns(Task.FromResult(nextDaysWeather));
            _weatherRequestService.Setup(wrs => wrs.GetWeather(coordinates2, days)).Returns(Task.FromResult(nextDaysWeather));

            _forecastService = new ForecastService(_cityRequestService.Object, _weatherRequestService.Object);

            List<WeatherResponse> expected = new List<WeatherResponse>
            {
                new WeatherResponse(citiesWeather.First().Name, nextDaysWeather),
                new WeatherResponse(citiesWeather.Last().Name, nextDaysWeather)
            };

            // Act
            var actual = await _forecastService.GetForecast();
            
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
