using System.Text.Json.Serialization;

namespace FieldsService.Models
{
    /// <summary>
    /// Represents earth coordinate in EPSG:4326 - WGS 84 coordinates system
    /// </summary>
    public class Coordinate
    {
        public Coordinate() { }
        public Coordinate(double longitude, double latitude) => (Longitude, Latitude) = (longitude, latitude);

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) 
                return true;

            if (obj == null) return false;

            if (obj is Coordinate objCoordinate)
            {
                return objCoordinate.Latitude == Latitude && objCoordinate.Longitude == Longitude;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode() => HashCode.Combine(Longitude, Latitude);
    }
}
