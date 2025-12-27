using System;
using MatrixLib; // Ссылка на библиотеку

namespace Lab10Variant4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Matrix matrix1 = new Matrix();
            Matrix matrix2 = new Matrix();

            // Для теста: сгенерируй и сохрани матрицы (убери, если файлы уже есть)
            matrix1.GenerateMatrix(3, 3);
            matrix1.SaveMatrix("matrix1.txt");
            matrix2.GenerateMatrix(3, 3);
            matrix2.SaveMatrix("matrix2.txt");

            // Загрузка и расчёт (основная логика)
            if (matrix1.LoadMatrix("matrix1.txt") && matrix2.LoadMatrix("matrix2.txt"))
            {
                Console.WriteLine("Матрица 1:");
                matrix1.PrintMatrix();

                Console.WriteLine("\nМатрица 2:");
                matrix2.PrintMatrix();

                float sumDiag1 = matrix1.SumDiagonal();
                float sumDiag2 = matrix2.SumDiagonal();
                float totalSum = sumDiag1 + sumDiag2;

                Console.WriteLine($"\nСумма диагональных элементов Матрицы 1: {sumDiag1}");
                Console.WriteLine($"Сумма диагональных элементов Матрицы 2: {sumDiag2}");
                Console.WriteLine($"Общая сумма диагональных элементов: {totalSum}");
            }
            else
            {
                Console.WriteLine("Ошибка загрузки матриц из файлов.");
            }

            Console.ReadKey();
        }
    }
}