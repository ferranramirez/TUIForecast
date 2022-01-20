using System;
using System.Collections.Generic;
using System.Text;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class WeatherRequestService : IWeatherRequestService
    {
        public IEnumerable<string> GetWeather(Coordinates coordinates, int days)
        {
            throw new NotImplementedException();
        }
    }
}
