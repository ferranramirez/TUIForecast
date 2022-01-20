namespace TUIForecast.Application.Domain.Model
{
    public class CityInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CityInfo info &&
                   Id == info.Id &&
                   Name == info.Name &&
                   Latitude == info.Latitude &&
                   Longitude == info.Longitude;
        }
    }
}
