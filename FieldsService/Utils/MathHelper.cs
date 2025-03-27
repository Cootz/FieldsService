using FieldsService.Models;

namespace FieldsService.Utils
{
    public static class MathHelper
    {
        public const double EARTH_RADIUS = 6_378_137;
        public static readonly Coordinate ReferencePoint = new(0, 90);

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

        /// <summary>
        /// Check if poing lies inside a polygon
        /// </summary>
        public static bool IsPointInsidePolygon(Coordinate point, Coordinate[] polygon)
        {
            double pointLatInRad = point.Latitude.ToRadians();
            double pointLngInRad = point.Longitude.ToRadians();

            double refPointLatInRad = ReferencePoint.Latitude.ToRadians();
            double refPointLngInRad = ReferencePoint.Longitude.ToRadians();

            double pointBearing = CalculateBearing(pointLatInRad, pointLngInRad, refPointLatInRad, refPointLngInRad);

            int intersectionsCount = 0;
            for (int i = 0; i < polygon.Length - 1; i++)
            {
                double edgeStartLatInRad = polygon[i].Latitude.ToRadians();
                double edgeStartLngInRad = polygon[i].Longitude.ToRadians();

                double edgeEndLatInRad = polygon[i+1].Latitude.ToRadians();
                double edgeEndLngInRad = polygon[i+1].Longitude.ToRadians();

                double edgeBearing = CalculateBearing(edgeStartLatInRad, edgeStartLngInRad, edgeEndLatInRad, edgeEndLngInRad);

                Vector3D pointV = ToVector3D(pointLatInRad, pointLngInRad);
                Vector3D edgeV = ToVector3D(edgeStartLatInRad, edgeStartLngInRad);

                Vector3D pointCircle = CalculateGreatCircle(pointLatInRad, pointLngInRad, pointBearing);
                Vector3D edgeCircle = CalculateGreatCircle(edgeStartLatInRad, edgeStartLngInRad, edgeBearing);

                Vector3D candidate1 = pointCircle.Cross(edgeCircle);
                Vector3D candidate2 = edgeCircle.Cross(pointCircle);

                int dir1 = Math.Sign(candidate1.Cross(pointV).Multiply(pointCircle));
                int dir2 = Math.Sign(candidate2.Cross(edgeV).Multiply(pointCircle));

                Vector3D? intersection = null;

                switch(dir1 + dir2)
                {
                    case 2:
                        intersection = candidate1;
                        break;
                    case -2:
                        intersection = candidate2;
                        break;
                    case 0:
                        intersection = pointV.Plus(pointCircle).Multiply(candidate1) > 0 ? candidate2 : candidate1;
                        break;
                }
 
                if (intersection is not null)
                {
                    intersectionsCount++;
                }
            }

            return intersectionsCount % 2 != 0;
        }

        private static Vector3D CalculateGreatCircle(double lat, double lng, double bearing)
        {
            double x = Math.Sin(lng) * Math.Cos(bearing) - Math.Sin(lat) * Math.Cos(lng) * Math.Sin(bearing);
            double y = -Math.Cos(lng) * Math.Cos(bearing) - Math.Sin(lat) * Math.Sin(lng) * Math.Sin(bearing);
            double z = Math.Cos(lat) * Math.Sin(bearing);

            return new Vector3D(x, y, z);
        }

        private static Vector3D ToVector3D(double lat, double lng)
        {
            (double Sin, double Cos) latSinCos = Math.SinCos(lat);
            (double Sin, double Cos) lngSinCos = Math.SinCos(lng);

            double x = latSinCos.Cos * lngSinCos.Cos;
            double y = latSinCos.Cos * lngSinCos.Sin;
            double z = latSinCos.Sin;

            return new Vector3D(x, y, z);
        }

        private static double CalculateBearing(double lat1, double lng1, double lat2, double lng2)
        {
            double lngDelta = lng2 - lng1;

            double y = Math.Sin(lngDelta) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lng2) * Math.Cos(lngDelta);
            return Math.Atan2(y, x);
        }
    }
}