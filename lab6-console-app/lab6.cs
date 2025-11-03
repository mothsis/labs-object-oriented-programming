using System;

class Point3D
{
    private double x, y, z; // координаты точки

    // конструктор по умолчанию
    public Point3D()
    {
        x = y = z = 0;
    }

    // конструктор с параметрами
    public Point3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Ввод координат
    public void Input()
    {
        Console.Write("Введите X: ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите Y: ");
        y = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите Z: ");
        z = Convert.ToDouble(Console.ReadLine());
    }

    // Вывод информации
    public void Print()
    {
        Console.WriteLine($"Точка: ({x}, {y}, {z})");
    }

    // Расстояние до начала координат
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    // Расстояние до другой точки
    public double DistanceTo(Point3D other)
    {
        return Math.Sqrt(
            Math.Pow(x - other.x, 2) +
            Math.Pow(y - other.y, 2) +
            Math.Pow(z - other.z, 2)
        );
    }

    // Debug / Release
    public void ShowBuildConfig()
    {
#if DEBUG
        Console.WriteLine("Режим сборки: DEBUG — выводим дополнительную информацию.");
        Console.WriteLine("Координаты: X={0}, Y={1}, Z={2}", x, y, z);
#else
        Console.WriteLine("Режим сборки: RELEASE — вывод краткой информации.");
#endif
    }
}

class Program
{
    static void Main()
    {
        Point3D p1 = new Point3D();
        p1.Input();
        p1.Print();

        // Debug / Release
        p1.ShowBuildConfig();

        Console.WriteLine("\nВведите координаты второй точки:");
        Point3D p2 = new Point3D(); 
        p2.Input();

        // Вычисление расстояний
        Console.WriteLine("\nРасстояние до начала координат: " +
            p1.DistanceFromOrigin().ToString("F2"));
        Console.WriteLine("Расстояние до второй точки: " +
            p1.DistanceTo(p2).ToString("F2"));

        Console.WriteLine("\nРабота завершена!!");
    }
}
