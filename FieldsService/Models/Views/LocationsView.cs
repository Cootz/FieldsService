using FieldsService.Models.Dtos;

namespace FieldsService.Models.Views
{
    public class LocationsView
    {
        public CoordinateDto Center { get; set; }
        public CoordinateDto[] Polygon {  get; set; }
    }
}