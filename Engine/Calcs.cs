using static System.Math;

namespace ASCII_Donut.Engine
{
    public static class Calcs
    {
        public static Point RotatePoint2D(Point point, double angle)
        {
            double rads = DegreesToRadians(angle);

            Point result = new() { Z = point.Z };
            result.X = point.X * Cos(rads) - point.Y * Sin(rads);
            result.Y = point.X * Sin(rads) + point.Y * Cos(rads);

            return result;
        }
        public static double DistanceBetweenPoints2D(Point p1, Point p2) =>
            Sqrt(Pow(p2.X - p1.X, 2) + Pow(p2.Y - p1.Y, 2));
        public static double GetAngle2D(Point p1, Point p2)
        {
            double verticalOffset = p2.Y - p1.Y;
            double horizontalOffset = p2.X - p1.X;

            if(horizontalOffset == 0)
            {
                if(verticalOffset > 0)
                    return 90;
                else
                    return -90;
            }

            double radians = Atan((verticalOffset) / (horizontalOffset));

            double degrees = RadiansToDegrees(radians);

            if(horizontalOffset < 0)
                degrees += 180;

            return degrees;
        }

        private static double DegreesToRadians(double degrees) =>
            degrees * PI / 180;
        private static double RadiansToDegrees(double radians) =>
            radians * 180 / PI;
    }
}
