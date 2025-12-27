using System;
using System.IO;

namespace MatrixLib
{
    public class Matrix
    {
        private float[,]? matrix;
        private int m, n;

        public Matrix()
        {
            matrix = null;
            m = 0;
            n = 0;
        }

        public void GenerateMatrix(int M, int N) // Для теста: случайная матрица
        {
            m = M;
            n = N;
            Random r = new Random(DateTime.Now.Millisecond);
            matrix = new float[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    matrix[i, j] = (float)r.Next(1000) / 973f;
        }

        public void SaveMatrix(string pFileName) // Сохранение в файл
        {
            if (matrix is not null && matrix.Length > 0)
            {
                if (File.Exists(pFileName)) File.Delete(pFileName);
                using StreamWriter tw = new StreamWriter(pFileName);
                tw.WriteLine(m);
                tw.WriteLine(n);
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        tw.WriteLine($"{i} {j} {matrix[i, j]:E10}");
            }
        }

        public bool LoadMatrix(string pFileName) // Загрузка из файла
        {
            if (!File.Exists(pFileName)) return false;
            try
            {
                using StreamReader tr = new StreamReader(pFileName);
                m = int.Parse(tr.ReadLine() ?? "0");
                n = int.Parse(tr.ReadLine() ?? "0");
                matrix = new float[m, n];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                    {
                        string? line = tr.ReadLine();
                        if (line == null) throw new Exception("Недостаточно данных");
                        string[] parts = line.Split(' ');
                        matrix[i, j] = float.Parse(parts[2]);
                    }
                return true;
            }
            catch { return false; }
        }

        public void PrintMatrix() // Вывод
        {
            if (matrix is not null && matrix.Length > 0)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                        Console.Write($"{matrix[i, j]:E3} ");
                    Console.WriteLine();
                }
            }
        }

        public float SumDiagonal() // Сумма главной диагонали
        {
            if (matrix is null || m != n) return 0;
            float sum = 0;
            for (int i = 0; i < m; i++) sum += matrix[i, i];
            return sum;
        }
    }
}