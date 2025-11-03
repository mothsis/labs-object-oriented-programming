using System;
using System.IO;

namespace Test
{
    class Program
    {
        // стандартные потоки вывода и ввода
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;

            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");

            Console.SetOut(new_out);
            Console.SetIn(new_in);
            
            // чтение данных
            int t = Convert.ToInt32(Console.ReadLine());
            int N = Convert.ToInt32(Console.ReadLine());
            double X = Convert.ToDouble(Console.ReadLine());
            double Y = Convert.ToDouble(Console.ReadLine());

            double Z = 0.0;
            int i = 1;

            // вычисления
            if (t == 0)
            {
                for (i = 1; i <= N; i++)
                {
                    double sign = (i % 2 == 0) ? -1.0 : 1.0;
                    Z += sign * (Math.Pow(Y, 2 * i) * Math.Pow(X, 2 * i - 1)) / (2 * i);
                }
            }
            else if (t == 1)
            {
                i = 1;
                while (i <= N)
                {
                    double sign = (i % 2 == 0) ? -1.0 : 1.0;
                    Z += sign * (Math.Pow(Y, 2 * i) * Math.Pow(X, 2 * i - 1)) / (2 * i);
                    i++;
                }
            }
            else if (t == 2)
            {
                i = 1;
                do
                {
                    double sign = (i % 2 == 0) ? -1.0 : 1.0;
                    Z += sign * (Math.Pow(Y, 2 * i) * Math.Pow(X, 2 * i - 1)) / (2 * i);
                    i++;
                } while (i <= N);
            }

            // вывод
            Console.WriteLine(String.Format("{0:0.0000000}", Z));

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
