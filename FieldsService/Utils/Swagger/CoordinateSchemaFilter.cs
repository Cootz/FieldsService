using FieldsService.Models.Dtos;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FieldsService.Utils.Swagger
{
    public class CoordinateSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type != typeof(CoordinateDto))
            {
                return;
            }

            schema.Type = "array";
            schema.Items = new OpenApiSchema
            {
                Type = "number",
                Format = "double"
            };
            schema.Description = "Coordinate represented as an array of [latitude, longitude].";
            schema.Example = new OpenApiArray
            {
                new OpenApiDouble(0),
                new OpenApiDouble(0)
            };
        }
    }
}
