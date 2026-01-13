using System;
using System.Threading;

namespace Logic
{
    // Пользовательский делегат
    public delegate int[,] MatrixGeneratorDelegate(int rows, int cols);

    public class MatrixGeneratorLogic
    {
        public static int[,] GenerateMatrix(int rows, int cols)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, cols];

            // Имитация длительной операции
            Thread.Sleep(3000);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rnd.Next(0, 2); // 0 или 1

            return matrix;
        }
    }
}
