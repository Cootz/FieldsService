using FieldsService.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FieldsServiceTests.ModelsTests.DtosTests
{
    public class CoordinateDtoTest
    {
        [TestCase(0, 0)]
        [TestCase(12, 35)]
        [TestCase(-40, -140)]
        public void ConvertsToJsonArrayTest(double lat, double lng)
        {
            CoordinateDto coordinate = new(lng, lat);

            string expected = $"[{lat},{lng}]";

            string jsonCoordinate = JsonSerializer.Serialize(coordinate);

            Assert.That(jsonCoordinate, Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(12, 35)]
        [TestCase(-40, -140)]
        public void ConvertsFromJsonToCoordinateTest(double lat, double lng)
        {
            string jsonString = $"[{lat},{lng}]";

            CoordinateDto? coordinate = JsonSerializer.Deserialize<CoordinateDto>(jsonString);

            Assert.That(coordinate, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(coordinate!.Latitude, Is.EqualTo(lat));
                Assert.That(coordinate!.Longitude, Is.EqualTo(lng));
            });
        }
    }
}
