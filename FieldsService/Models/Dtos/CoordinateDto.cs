using FieldsService.Utils.JsonConverters;
using System.Text.Json.Serialization;

namespace FieldsService.Models.Dtos
{
    [JsonConverter(typeof(CoordinateDtoJsonConverter))]
    public class CoordinateDto
    {
        public CoordinateDto() { }
        public CoordinateDto(double longitude, double latitude) => (Longitude, Latitude) = (longitude, latitude);

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
