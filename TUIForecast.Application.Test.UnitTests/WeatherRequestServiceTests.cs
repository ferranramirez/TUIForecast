using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;
using TUIForecast.Application.Impl.RequestServices;
using Xunit;

namespace TUIForecast.Application.Test.UnitTests
{
    public class WeatherRequestServiceTests : TestUtilities
    {
        private IWeatherRequestService _weatherRequestService;
        private readonly int days = 2;

        [Fact]
        public async Task GetWeather_GivenRightCoordinatesFor2DaysForecast_ReturnsExpectedTwoDaysWeather()
        {
            // Arrange
            var weather = "{'forecast': {'forecastday': " +
                "[{'day': {'condition': {'text': 'Rainy'}}}," +
                "{'day': {'condition': {'text': 'Cloudy'}}}]}}";
            _weatherRequestService = new WeatherRequestService(MockHttpClient_OK(weather));

            IEnumerable<string> expected = new List<string>() { "Rainy", "Cloudy" };
            var coordinates = new Coordinates(52.374, 4.9);

            // Act
            var result = await _weatherRequestService.GetWeather(coordinates, days);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetAll_WhenExternalAPINotWorking_ThrowsException()
        {
            // Arrange
            var coordinates = new Coordinates(52.374, 4.9);
            _weatherRequestService = new WeatherRequestService(MockHttpClient_KO());

            // Act
            async Task action() => await _weatherRequestService.GetWeather(coordinates, days);

            // Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(action);
            Assert.Equal("The request failed", exception.Message);
        }
    }
}
