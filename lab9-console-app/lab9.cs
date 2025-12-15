using System;

interface ICalculable
{
    void Plus(int value);
    void Minus(int value);
    void DrawObject();
}

public class Human : ICalculable
{
    public string FIO;
    private int Age;

    public Human(string pFIO, int pAge)
    {
        FIO = pFIO;
        Age = pAge;
    }

    public void Plus(int pPlus)
    {
        Age += pPlus;
    }

    public void Minus(int pMinus)
    {
        Age -= pMinus;
    }

    public string Name
    {
        get
        {
            return FIO + " : " + Age.ToString();
        }
    }

    public void DrawObject()
    {
        Console.WriteLine(
            "        O       \n" +
            "  ------------  \n" +
            "        |       \n" +
            "       / \\     \n" +
            "      /   \\    \n"
        );
        Console.WriteLine(Name);
    }
}

public class Car : ICalculable
{
    private string Manufacturer;
    private string Model;
    private int Velocity;

    public Car(string pManufacturer, string pModel, int pVelocity)
    {
        Manufacturer = pManufacturer;
        Model = pModel;
        Velocity = pVelocity;
    }

    public void Plus(int pPlus)
    {
        Velocity += pPlus;
    }

    public void Minus(int pMinus)
    {
        Velocity -= pMinus;
    }

    public string Name
    {
        get
        {
            return Manufacturer + " - " + Model +
                   " : " + Velocity.ToString() + " km/h";
        }
    }

    public void DrawObject()
    {
        Console.WriteLine(
            "     --------------         \n" +
            "____/             \\_____   \n" +
            "|                        |  \n" +
            "----(@)-----------(@)----  \n"
        );
        Console.WriteLine(Name);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();

        Console.Title = "Лабораторная работа №9";

        // Полиморфизм через интерфейс
        ICalculable h = new Human("Крутой человек", 40);
        h.Plus(5);
        h.Minus(1);
        h.DrawObject();

        Console.WriteLine("\n\n");

        ICalculable car = new Car("Крутая машина", "ix35", 120);
        car.Plus(25);
        car.Minus(11);
        car.DrawObject();

        Console.ReadKey();
    }
}
