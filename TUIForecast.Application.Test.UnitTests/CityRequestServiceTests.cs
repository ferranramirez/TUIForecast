using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;
using TUIForecast.Application.Impl.RequestServices;
using Xunit;

namespace TUIForecast.Application.Test.UnitTests
{
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

        [Fact]
        public async Task GetAll_WhenExternalAPINotWorking_ThrowsException()
        {
            // Arrange
            _cityRequestService = new CityRequestService(MockHttpClient_KO());

            // Act
            async Task action() => await _cityRequestService.GetAll();

            // Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(action);
            Assert.Equal("The request failed", exception.Message);
        }
    }
}
