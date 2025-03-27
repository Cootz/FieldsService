using FieldsService.Models;
using FieldsService.Models.Dtos;
using System.Drawing.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FieldsService.Utils.JsonConverters
{
    internal class CoordinateDtoJsonConverter : JsonConverter<CoordinateDto>
    {
        public override CoordinateDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            reader.Read();
            double latitude = reader.GetDouble();
            reader.Read();
            double longitude = reader.GetDouble();
            reader.Read();

            if (reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException("Expected end of array");

            return new CoordinateDto(longitude, latitude);
        }

        public override void Write(Utf8JsonWriter writer, CoordinateDto value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Latitude);
            writer.WriteNumberValue(value.Longitude);
            writer.WriteEndArray();
        }
    }
}
