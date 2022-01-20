using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TUIForecast.Application.Contract;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl
{
    public partial class ForecastService : IForecastService
    {
        private readonly ICityRequestService _cityRequestService;
        private readonly IWeatherRequestService _weatherRequestService;

        private const int days = 2;

        public ForecastService(
            ICityRequestService cityRequestService,
            IWeatherRequestService weatherRequestService)
        {
            _cityRequestService = cityRequestService;
            _weatherRequestService = weatherRequestService;
        }

        public async IAsyncEnumerable<WeatherResponse> GetForecast()
        {
            var cities = await _cityRequestService.GetAll();

            foreach (var city in cities)
            {
                var weatherList = await _weatherRequestService
                    .GetWeather(new Coordinates(city.Latitude, city.Longitude), days);

                yield return new WeatherResponse(city.Name, weatherList);
            }
        }
    }
}
