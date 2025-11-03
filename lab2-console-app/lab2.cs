using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            // ввод значений
            double a1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double a2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double a3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double a4 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double a5 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // проверка
            if (a3 == 0 || a1 == 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            double underRootS = a2 - a5;
            if (underRootS < 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            double underRootK = (a3 / a1) * (a2 * a2);
            if (underRootK < 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            // вычисление
            double s = a1 * Math.Sqrt(underRootS) / a3;
            double k = Math.Sqrt(underRootK);

            // округление до сотых
            Console.WriteLine($"{Math.Round(s, 2):F2} {Math.Round(k, 2):F2}");
        }
        catch
        {
            Console.WriteLine("ERROR");
        }
    }
}