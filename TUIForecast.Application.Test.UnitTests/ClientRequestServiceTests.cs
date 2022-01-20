using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TUIForecast.Application.Contract;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;
using TUIForecast.Application.Impl;
using TUIForecast.Application.Impl.RequestServices;
using Xunit;

namespace TUIForecast.Application.Test.UnitTests
{
    public class ClientRequestServiceTests
    {
        private Mock<ICityRequestService> _cityRequestService;
        private Mock<IWeatherRequestService> _weatherRequestService;
        private IForecastService _forecastService;

        private readonly int days = 2;

        public ClientRequestServiceTests()
        {
            _cityRequestService = new Mock<ICityRequestService>();
            _weatherRequestService = new Mock<IWeatherRequestService>();

        }

        public class CityRequestServiceTests : TestUtilities
        {
            private ICityRequestService _cityRequestService;

            [Fact]
            public async void GetAll_ReturnsExpectedListWithTwoCities()
            {
                // Arrange
                var cities = "[{'name':'TestCity1','latitude': 52.374, 'longitude': 4.9}, " +
                    "{'name':'TestCity2','latitude': 99.999, 'longitude': 9.9}]";
                _cityRequestService = new CityRequestService(MockHttpClient_OK(cities));

                var expected = JsonConvert.DeserializeObject<IEnumerable<CityInfo>>(cities);

                // Act
                var result = await _cityRequestService.GetAll();

                // Assert
                Assert.Equal(expected, result);
            }
        }
    }
}
