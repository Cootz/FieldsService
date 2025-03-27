using FieldsService.Models;
using FieldsService.Models.Dtos;

namespace FieldsService.Utils.Extensions
{
    public static class CoordinateExtensions
    {
        public static Coordinate ToModel(this CoordinateDto coordinate) => new(coordinate.Longitude, coordinate.Latitude);

        public static CoordinateDto ToDto(this Coordinate coordinate) => new(coordinate.Longitude, coordinate.Latitude);
    }
}
