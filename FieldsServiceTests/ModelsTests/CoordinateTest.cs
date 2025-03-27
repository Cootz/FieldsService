using FieldsService.Models;
using FieldsServiceTests.TestData.ModelsTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FieldsServiceTests.ModelsTests
{
    public class CoordinateTest
    {
        [Test]
        public void EqualByValueTest()
        {
            Coordinate c1 = CoordinateTestData.ExampleCoordinate;

            // Create value copy
            Coordinate c2 = new()
            {
                Latitude = c1.Latitude,
                Longitude = c1.Longitude,
            };

            Assert.That(c1, Is.EqualTo(c2));
        }

        [Test]
        public void EqualByLinkTest()
        {
            Coordinate c1 = CoordinateTestData.ExampleCoordinate;

            Coordinate c2 = c1;

            Assert.That(c1, Is.EqualTo(c2));
        }

        [Test]
        public void NotEqualToNullTest()
        {
            Coordinate c1 = CoordinateTestData.ExampleCoordinate;

            Assert.That(c1, Is.Not.EqualTo(null));
        }

        [Test]
        public void NotEqualToObject()
        {
            Coordinate c1 = CoordinateTestData.ExampleCoordinate;

            Assert.That(c1, Is.Not.EqualTo(new object()));
        }
    }
}
