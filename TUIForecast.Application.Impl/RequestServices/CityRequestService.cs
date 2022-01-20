using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class CityRequestService : ICityRequestService
    {
        private readonly HttpClient _httpClient;
        public CityRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CityInfo>> GetAll()
        {
            var httpResponse = await _httpClient.GetAsync(RequestResources.CitiesUrl);
            var strResponse = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CityInfo>>(strResponse);
        }
    }
}
