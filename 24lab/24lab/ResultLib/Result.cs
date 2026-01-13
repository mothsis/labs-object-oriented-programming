using System;

namespace _24lab.ResultLib
{
    public static class Result
    {
        public static void ShowMaxArea(double a, double b, double area)
        {
            Console.WriteLine(
                $"Прямоугольник с наибольшей площадью: a={a}, b={b}, S={area}");
        }

        public static void ShowMaxDiagonal(double a, double b, double diagonal)
        {
            Console.WriteLine(
                $"Прямоугольник с наибольшей диагональю: a={a}, b={b}, D={diagonal:F2}");
        }
    }
}
