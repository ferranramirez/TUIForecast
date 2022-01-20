using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TUIForecast.Application.Contract;

namespace TUIForecast.Presentation.CLI
{
    class Program : ProgramBase
    {
        static async Task Main(string[] args)
        {
            var startup = new Startup();

            var _forecastService = startup.Provider.GetService<IForecastService>();

            await foreach (var forecast in _forecastService.GetForecast())
            {
                PrintForecastLine(forecast);
            }
        }
    }
}
