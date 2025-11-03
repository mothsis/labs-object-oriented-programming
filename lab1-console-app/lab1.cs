using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Персональная информация 
            Console.WriteLine("Лабораторная работа №1");
            Console.WriteLine("");
            Console.WriteLine("Выполнила: Богославец Елизавета Романовна");
            Console.WriteLine("Группа: ИСиТ-О-24/4; ШИфр специальности: 09.03.02");
            Console.WriteLine("Наименование ЛР: Структура консольного приложения");
            Console.WriteLine("Населенный пункт: г. Ставрополь");
            Console.WriteLine("Любимый предмет в школе: История");
            Console.WriteLine("Увлечения: любой вид прикладного творчества, всего по немногу\n");

            //Вариант 4
            double gh = 1;   // пример значения
            double b = 2;    // пример значения
            double q3 = 3;   // пример значения
            double x = 4;   // пример значения
            double y = 5;   // пример значения
            double w = 6;   // пример значения

            double c = (gh + b * q3 - x + y / w);

            Console.WriteLine($"Вариант 4:");
            Console.WriteLine($"gh = {gh}, b = {b}, q3 = {q3}, x = {x}, y = {y}, w = {w}");
            Console.WriteLine($"c = {c:F2}");
        }
    }
}
