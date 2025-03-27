using FieldsService.Models;
using FieldsService.Models.Views;

namespace FieldsService.Utils.Extensions
{
    public static class FieldExtensions
    {
        public static FieldView ToView(this Field field) => new()
        {
            Id = field.Id,
            Name = field.Name,
            Size = field.Size,
            Locations = new()
            {
                Center = field.Center.ToDto(),
                Polygon = field.Bounderies.Select(coordinate => coordinate.ToDto()).ToArray()
            }
        };

        public static ShortFieldView ToShortView(this Field field) => new()
        {
            Id = field.Id,
            Name = field.Name
        };
    }
}
