using System;
using _24lab.Figures;
using _24lab.ResultLib;

namespace _24lab.RectanglesApp
{
    class Testing
    {
        public void Run()
        {
            Console.Write("Введите количество прямоугольников: ");
            int n = int.Parse(Console.ReadLine());

            double maxArea = 0;
            double maxDiag = 0;

            double aArea = 0, bArea = 0;
            double aDiag = 0, bDiag = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\nПрямоугольник {i + 1}\nВведите a: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Введите b: ");
                double b = double.Parse(Console.ReadLine());

                double area = RectangleTask.Area(a, b);
                double diag = RectangleTask.Diagonal(a, b);

                if (area > maxArea)
                {
                    maxArea = area;
                    aArea = a;
                    bArea = b;
                }

                if (diag > maxDiag)
                {
                    maxDiag = diag;
                    aDiag = a;
                    bDiag = b;
                }
            }

            Console.WriteLine();
            Result.ShowMaxArea(aArea, bArea, maxArea);
            Result.ShowMaxDiagonal(aDiag, bDiag, maxDiag);
        }
    }
}
