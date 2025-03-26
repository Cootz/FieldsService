using System.Text.Json.Serialization;

namespace FieldsService.Models
{
    /// <summary>
    /// Represents earth coordinate in EPSG:4326 - WGS 84 coordinates system
    /// </summary>
    public class Coordinate
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
