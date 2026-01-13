using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер векторов: ");
        int size = int.Parse(Console.ReadLine());

        // Создание параметризованного потока
        Thread thread = new Thread(new ParameterizedThreadStart(ScalarProduct));

        Console.WriteLine("Запуск вычисления в отдельном потоке\n");

        // Передача параметра в поток
        thread.Start(size);

        // Ожидание завершения потока
        thread.Join();

        Console.WriteLine("\n Вычисление завершено.");
        Console.ReadKey();
    }

    static void ScalarProduct(object obj)
    {
        int n = (int)obj;

        int[] vectorA = new int[n];
        int[] vectorB = new int[n];

        Random rnd = new Random();

        // Формирование случайных векторов
        for (int i = 0; i < n; i++)
        {
            vectorA[i] = rnd.Next(1, 10);
            vectorB[i] = rnd.Next(1, 10);
        }

        Console.WriteLine("Вектор A:");
        PrintVector(vectorA);

        Console.WriteLine("Вектор B:");
        PrintVector(vectorB);

        int scalar = 0;

        for (int i = 0; i < n; i++)
            scalar += vectorA[i] * vectorB[i];

        Console.WriteLine("\n Скалярное произведение: " + scalar);
    }

    static void PrintVector(int[] v)
    {
        foreach (int x in v)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
