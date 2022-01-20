using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Contract
{
    public interface IForecastService
    {
        Task<IEnumerable<WeatherResponse>> GetForecast();
    }
}
