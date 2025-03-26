using Aspose.Gis;
using Aspose.Gis.Geometries;
using FieldsService.Models;
using System.Collections.Frozen;
using Point = Aspose.Gis.Geometries.Point;

namespace FieldsService.Repositories
{
    public class FieldsRepository : IFieldsRepository
    {
        private readonly FieldsRepositoryOptions _options;

        private FrozenDictionary<double, Field>? _fields;

        public FieldsRepository(FieldsRepositoryOptions options) => _options = options;

        public void LoadData()
        {
            string pathToFields = Path.Combine(_options.PathToData, "fields.kml");
            string pathToCentroids = Path.Combine(_options.PathToData, "centroids.kml");

            Dictionary<double, Field> fields = [];

            using (var layer = Drivers.Kml.OpenLayer(pathToFields))
            {
                foreach (Feature feature in layer)
                {
                    Field field = new();

                    field.Id = feature.GetValue<double>("fid");
                    field.Size = feature.GetValue<double>("size");
                    field.Name = feature.GetValue<string>("name");

                    Polygon polygon = feature.Geometry as Polygon ?? throw new NullReferenceException("Field geometry is null");
                    
                    field.Bounderies = polygon.ExteriorRing.Select(coordinate => new Coordinate(coordinate.X, coordinate.Y)).ToArray();

                    fields.Add(field.Id, field);
                }
            }

            using (var layer = Drivers.Kml.OpenLayer(pathToCentroids))
            {
                foreach (Feature feature in layer)
                {
                    double fieldId = feature.GetValue<double>("fid");

                    if (!fields.TryGetValue(fieldId, out Field? field))
                    {
                        throw new KeyNotFoundException($"Field with id {fieldId} was not found");
                    }

                    Point centroid = feature.Geometry as Point ?? throw new NullReferenceException("Field geometry is null");

                    field.Center = new Coordinate(centroid.X, centroid.Y);
                }
            }

            _fields = fields.ToFrozenDictionary();
        }

        public Field? FindById(double id) => _fields!.GetValueOrDefault(id);

        public IEnumerable<Field> GetAll() => _fields!.Values.ToArray();
    }
}
