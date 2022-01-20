using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TUIForecast.Application.Impl.RequestServices
{
    public abstract class RequestBase
    {
        private readonly HttpClient _httpClient;

        public RequestBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<string> GetResponse(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
                return await httpResponse.Content.ReadAsStringAsync();

            throw new HttpRequestException("The request failed");
        }
    }
}