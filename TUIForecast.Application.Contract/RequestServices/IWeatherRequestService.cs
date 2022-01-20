using System.Collections.Generic;
using System.Threading.Tasks;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Contract.RequestServices
{
    public interface IWeatherRequestService
    {
        Task<IEnumerable<string>> GetWeather(Coordinates coordinates, int days);
    }
}
