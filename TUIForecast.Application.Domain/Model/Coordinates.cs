using System;

namespace TUIForecast.Application.Domain.Model
{
    public class Coordinates
    {
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Coordinates coordinates &&
                   Latitude == coordinates.Latitude &&
                   Longitude == coordinates.Longitude;
        }
    }
}
