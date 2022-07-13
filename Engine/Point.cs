namespace ASCII_Donut.Engine
{
    public class Point
    {
        public double X = 0;
        public double Y = 0;
        public double Z = 0;

        public Point() { }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point operator+(Point p1, Point p2)
        {
            return new Point (
                p1.X + p2.X,
                p1.Y + p2.Y,
                p1.Z + p2.Z);
        }
    }
}
