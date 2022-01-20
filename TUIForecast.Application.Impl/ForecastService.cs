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

        public async Task<IEnumerable<WeatherResponse>> GetForecast()
        {
            var response = new List<WeatherResponse>();

            var cities = await _cityRequestService.GetAll();

            foreach (var city in cities)
            {
                var weatherList = _weatherRequestService
                    .GetWeather(new Coordinates(city.Latitude, city.Longitude), days);

                response.Add(new WeatherResponse(city.Name, weatherList));
            }

            return response;
        }
    }
}
