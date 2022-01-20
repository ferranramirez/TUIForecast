using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class WeatherRequestService : IWeatherRequestService
    {
        private readonly HttpClient _httpClient;
        public WeatherRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetWeather(Coordinates coordinates, int days)
        {
            string requestUrl = string.Format(RequestResources.WeatherUrl, RequestResources.Key,
                    coordinates.Latitude.ToString(CultureInfo.InvariantCulture),
                    coordinates.Longitude.ToString(CultureInfo.InvariantCulture), days);

            var httpResponse = await _httpClient.GetAsync(requestUrl);
            var strResponse = await httpResponse.Content.ReadAsStringAsync();
            var weatherObject = JObject.Parse(strResponse);

            return weatherObject["forecast"]["forecastday"]
                    .Select(forecast => forecast["day"]["condition"]["text"].ToString());
        }
    }
}
