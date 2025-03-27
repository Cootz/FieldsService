namespace FieldsService.Models.Dtos
{
    public class DistanceToCenterReqiest
    {
        public double FieldId { get; set; }
        public CoordinateDto Coordinate { get; set; }
    }
}
