using FieldsService.Models;
namespace FieldsService.Utils
{
    public static class MathHelper
    {
        public const double EARTH_RADIUS = 6_378_137;

        /// <summary>
        /// Calculates distance between two points in EPSG:4326 coordinates system
        /// </summary>
        /// <returns>Distance between given points in meters</returns>
        public static double CalculateDistance(Coordinate a, Coordinate b)
        { 
            double latAInRad = a.Latitude.ToRadians();
            double lngAInRad = a.Longitude.ToRadians();

            double latBInRad = b.Latitude.ToRadians();
            double lngBInRad = b.Longitude.ToRadians();

            double deltaLat = latBInRad - latAInRad;
            double deltaLng = lngBInRad - lngAInRad;

            // Use haversin formula to calculate distance between 2 points on a sphere
            return 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(Haversin(deltaLat) + Math.Cos(latAInRad) * Math.Cos(latBInRad) * Haversin(deltaLng)));
        }

        public static double ToRadians(this double angle) => Math.PI * angle / 180;

        public static double Haversin(double angleInRad) => Math.Pow(Math.Sin(angleInRad / 2), 2);
    }
}
