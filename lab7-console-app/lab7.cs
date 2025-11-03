using System;

class Cylinder
{
    private double radius;
    private double height;

    // Перегруженные конструкторы
    public Cylinder()
    {
        radius = 1;
        height = 1;
    }

    public Cylinder(double r, double h)
    {
        radius = r;
        height = h;
    }

    public Cylinder(double r)
    {
        radius = r;
        height = 1;
    }

    // пперегруженные методы для установки значений
    public void SetValues(double r, double h)
    {
        radius = r;
        height = h;
    }

    public void SetValues(double r)
    {
        radius = r;
    }

    // Вычисление объёма
    public double Volume()
    {
        return Math.PI * radius * radius * height;
    }

    // Площадь поверхности цилиндра
    public double Area()
    {
        return 2 * Math.PI * radius * (radius + height);
    }

    // Вывод информации 
    public void Print()
    {
        Console.WriteLine($"Цилиндр: r = {radius}, h = {height}");
        Console.WriteLine($"Объём: {Volume():F3}");
        Console.WriteLine($"Площадь поверхности: {Area():F3}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите радиус цилиндра:");
        double r = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите высоту цилиндра:");
        double h = double.Parse(Console.ReadLine());

        // основной конструктор
        Cylinder cyl = new Cylinder(r, h);

        // Debug/Release
#if DEBUG
        Console.WriteLine("DEBUG: Вывод полной информации об объекте");
        cyl.Print();
#else
        Console.WriteLine("RELEASE: Вывод только объёма");
        Console.WriteLine($"Объём: {cyl.Volume():F3}");
#endif

        Console.ReadKey();
    }
}
