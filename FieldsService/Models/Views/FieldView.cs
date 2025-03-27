namespace FieldsService.Models.Views
{
    public class FieldView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public LocationsView Locations { get; set; }
    }
}