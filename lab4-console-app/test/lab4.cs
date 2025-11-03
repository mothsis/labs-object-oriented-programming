using System;
using System.IO;
using System.Linq;
using System.Globalization;

class Program
{
    static void Main()
    {
        TextReader save_in = Console.In;
        TextWriter save_out = Console.Out;

        Console.SetIn(new StreamReader("input.txt"));
        Console.SetOut(new StreamWriter("output.txt"));

        int n = int.Parse(Console.ReadLine());
        double[] arr = Console.ReadLine()
            .Split(' ')
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

        double max = arr.Max();
        double min = arr.Min();

        double avgMinMax = (max + min) / 2.0;
        double avgAll = arr.Average();

        Console.WriteLine($"{avgMinMax:F3}");
        Console.WriteLine($"{avgAll:F3}");

        foreach (double x in arr)
            if (x > avgMinMax)
                Console.Write($"{x:F3} ");

        Console.Out.Flush();
        Console.SetIn(save_in);
        Console.SetOut(save_out);

        Console.WriteLine("Результат записан в output.txt!");
    }
}
