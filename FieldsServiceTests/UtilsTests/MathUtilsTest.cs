using FieldsService.Models;
using FieldsService.Utils;

namespace FieldsServiceTests.UtilsTests
{
    public class MathUtilsTest
    {
        [TestCase(30.96, 120.08, 30.96, 120.08, 0)]
        [TestCase(30.96, 120.08, 30.92, 120.08, 4452.78)]
        [TestCase(30.96, 120.08, 30.96, 120.1, 1909.19)]
        [TestCase(90, 0, -90, 0, MathHelper.EARTH_RADIUS*Math.PI)]
        [TestCase(0, 0, 0, 1, 111319.49)]

        public void CalculateDistanceTest(double latA, double lngA, double latB, double lngB, double expectedResult)
        {
            double result = MathHelper.CalculateDistance(new Coordinate(lngA, latA), new Coordinate(lngB, latB));

            Assert.That(result, Is.EqualTo(expectedResult).Within(0.01d));
        }
    }
}
