namespace ASCII_Donut.Engine
{
    public class Rotation
    {
        public double X
        {
            get => _x;
            set { _x = ValidateValue(value); }
        }
        public double Y
        {
            get => _y;
            set { _y = ValidateValue(value); }
        }
        private double _x = 0;
        private double _y = 0;

        public Rotation() {}
        public Rotation(double x, double y)
        {
            SetValue(x, y);
        }

        public void SetValue(double x, double y)
        {
            _x = x;
            _y = y;
        }

        private static double ValidateValue(double value)
        {
            if (value > 180)
                value -= 360;
            if (value < -180)
                value += 360;

            return value;
        }

        public static Rotation operator+(Rotation r1, Rotation r2)
        {
            return new Rotation(
                r1.X + r2.X,
                r1.Y + r2.Y);
        }
    }
}
