namespace FieldsService.Models
{
    public class Vector3D
    {
        public double X { get; set; }   
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z) => (X, Y, Z) = (x, y, z);

        public Vector3D Cross(Vector3D vector)
        {
            double x = X * vector.Z - Z * vector.Y;
            double y = Z * vector.X - X * vector.Z;
            double z = X * vector.Y - Y * vector.X;

            return new Vector3D(x, y, z);
        }

        public double Multiply(Vector3D vector) => X * vector.X + Y * vector.Y + Z * vector.Z;

        public Vector3D Plus(Vector3D vector) => new(X + vector.X, Y + vector.Y, Z + vector.Z);
    }
}
