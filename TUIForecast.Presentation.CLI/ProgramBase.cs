using System;
using System.Linq;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Presentation.CLI
{
    public class ProgramBase
    {
        protected static void PrintForecastLine(WeatherResponse weatherResponse)
        {
            var weatherText = string.Empty;
            weatherResponse.WeatherCondition.ToList().ForEach(w => ConcatAllWeathers(w, ref weatherText));
            Console.WriteLine(string.Format(("Processed city {0} | {1}\n"), weatherResponse.CityName, weatherText));
        }

        private static void ConcatAllWeathers(string w, ref string weatherText)
        {
            if (!weatherText.Equals(string.Empty))
            {
                weatherText = string.Concat(weatherText, " - ");
            }
            weatherText = string.Concat(weatherText, w);
        }

    }
}