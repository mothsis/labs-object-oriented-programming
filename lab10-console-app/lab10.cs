using System;
using MatrixLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        
        Matrix m = new Matrix();
        m.GenerateMatrix(10, 5);
        m.SaveMatrix("FileForMatrix.txt");
        
        if (m.LoadMatrix("FileForMatrix.txt"))
        {
            m.PrintMatrix();
        }
        
        Console.ReadKey();
    }
}