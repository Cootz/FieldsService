namespace FieldsService.Models
{
    public class Field
    {
        public double Id { get; set; }
        public string Name { get; set; } = default!;
        public double Size { get; set; }
        public Coordinate[] Bounderies { get; set; } = default!;
        public Coordinate Center { get; set; } = default!;
    }
}
