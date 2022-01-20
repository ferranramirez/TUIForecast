using System.Collections.Generic;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Contract
{
    public interface IForecastService
    {
        IAsyncEnumerable<WeatherResponse> GetForecast();
    }
}
