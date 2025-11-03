using System;
using System.IO;

namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // чтение размеров матрицы из файла
            int M, N;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                M = int.Parse(sr.ReadLine()); // количество строк
                N = int.Parse(sr.ReadLine()); // количество столбцов
            }

            Random rnd = new Random();
            int[,] matrix = new int[M, N];
            double[] avg = new double[N]; // средние значения 

            // генерация случайных чисел в матрице
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    matrix[i, j] = rnd.Next(-100, 101);

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                // вывод исходной матрицы в файл
                sw.WriteLine("Исходная матрица:");
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                        sw.Write($"{matrix[i, j],5}");
                    sw.WriteLine();
                }
                sw.WriteLine();

                // вычисление средних значений столбцов
                for (int j = 0; j < N; j++)
                {
                    double sum = 0;
                    for (int i = 0; i < M; i++)
                        sum += matrix[i, j];

                    avg[j] = sum / M;
                }

                // вывод средних значений
                sw.WriteLine("Среднее арифметическое столбцов:");
                for (int j = 0; j < N; j++)
                    sw.Write($"{avg[j]:F2} ");
                sw.WriteLine("\n");

                // формирование и вывод модифицированной матрицы
                sw.WriteLine("Модифицированная матрица:");
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        // сравнение элемента со средним значением столбца
                        sw.Write(matrix[i, j] < avg[j] ? "  X  " : "  Y  ");
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine("Готово! Результаты в файле output.txt");
        }
    }
}
