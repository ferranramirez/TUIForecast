using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class CityRequestService : RequestBase, ICityRequestService
    {
        public CityRequestService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IEnumerable<CityInfo>> GetAll()
        {
            var strResponse = await GetResponse(RequestResources.CitiesUrl);
            return JsonConvert.DeserializeObject<IEnumerable<CityInfo>>(strResponse)
                .OrderBy(c => c.Id);
        }
    }
}
