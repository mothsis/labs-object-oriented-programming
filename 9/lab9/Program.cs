using System;

namespace Lab9
{
    interface ICalculator
    {
        double Calculate(double value, int power);
    }

    class SinPart : ICalculator
    {
        public double Calculate(double value, int power)
        {
            return Math.Sin(value) * Math.Pow(value, power);
        }
    }

    class PowerPart : ICalculator
    {
        public double Calculate(double value, int power)
    {
        return Math.Pow(value, power);
    }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x, y, f, N, K:");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double f = double.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            ICalculator sinCalculator = new SinPart();
            ICalculator powerCalculator = new PowerPart();

            double Z = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    Z += sinCalculator.Calculate(x, i) + powerCalculator.Calculate(f, j) * Math.Pow(y, j);
                }
            }

            Console.WriteLine("Z = " + Z);
        }
    }
}