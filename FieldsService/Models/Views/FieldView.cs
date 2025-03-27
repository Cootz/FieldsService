namespace FieldsService.Models.Views
{
    public class FieldView
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public LocationsView Locations { get; set; }
    }
}