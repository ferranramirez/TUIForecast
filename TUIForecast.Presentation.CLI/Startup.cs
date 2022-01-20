using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using TUIForecast.Application.Contract;
using TUIForecast.Application.Impl;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Impl.RequestServices;

namespace TUIForecast.Presentation.CLI
{
    public class Startup
    {
        private readonly IServiceProvider provider;
        public IServiceProvider Provider => provider;

        public Startup()
        {
            provider =
                new ServiceCollection()
                  .AddSingleton<HttpClient>()
                  .AddSingleton<ICityRequestService, CityRequestService>()
                  .AddSingleton<IWeatherRequestService, WeatherRequestService>()
                  .AddSingleton<IForecastService, ForecastService>()
                  .BuildServiceProvider();
        }
    }
}