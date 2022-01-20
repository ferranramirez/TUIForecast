using System;

namespace TUIForecast.Application.Domain.Model
{
    public class CityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
