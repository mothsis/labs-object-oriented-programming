using System;

namespace _24lab.Figures
{
    public static class RectangleTask
    {
        public static double Area(double a, double b)
        {
            return a * b;
        }

        public static double Diagonal(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }
    }
}
