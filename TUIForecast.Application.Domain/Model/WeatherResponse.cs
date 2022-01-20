using System;
using System.Collections.Generic;

namespace TUIForecast.Application.Domain.Model
{
    public class WeatherResponse
    {
        public WeatherResponse(string cityName, IEnumerable<string> weatherCondition)
        {
            CityName = cityName;
            WeatherCondition = weatherCondition;
        }

        public string CityName { get; set; }
        public IEnumerable<string> WeatherCondition { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WeatherResponse response &&
                   CityName == response.CityName &&
                   EqualityComparer<IEnumerable<string>>.Default.Equals(WeatherCondition, response.WeatherCondition);
        }
    }
}
