using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class WeatherRequestService : RequestBase, IWeatherRequestService
    {
        public WeatherRequestService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IEnumerable<string>> GetWeather(Coordinates coordinates, int days)
        {
            string requestUrl = string.Format(RequestResources.WeatherUrl, RequestResources.Key,
                    coordinates.Latitude.ToString(CultureInfo.InvariantCulture),
                    coordinates.Longitude.ToString(CultureInfo.InvariantCulture), days);

            var strResponse = await GetResponse(requestUrl);
            var weatherObject = JObject.Parse(strResponse);

            return weatherObject["forecast"]["forecastday"]
                    .Select(forecast => forecast["day"]["condition"]["text"].ToString());
        }
    }
}
