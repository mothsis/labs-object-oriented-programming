using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmployeeLib;  // Ссылка на библиотеку

namespace Lab11Variant4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            List<Employee> employees = new List<Employee>();

            // Загрузка данных из файла
            string fileName = "employees.txt";
            if (File.Exists(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 3)
                        {
                            string company = parts[0].Trim();
                            double salary = double.Parse(parts[1].Trim());
                            bool knowsEnglish = parts[2].Trim().ToLower() == "yes";
                            employees.Add(new Employee(company, salary, knowsEnglish));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Файл employees.txt не найден.");
                Console.ReadKey();
                return;
            }

            if (employees.Count == 0)
            {
                Console.WriteLine("Нет данных о сотрудниках.");
                Console.ReadKey();
                return;
            }

            // 1. Количество сотрудников в каждой из 4-х компаний
            var countByCompany = employees.GroupBy(e => e.Company)
                                         .Select(g => new { Company = g.Key, Count = g.Count() });
            Console.WriteLine("1. Количество сотрудников в каждой компании:");
            foreach (var item in countByCompany)
                Console.WriteLine($"Компания {item.Company}: {item.Count}");

            // 2. Средняя з/п в каждой из 4-х компаний
            var avgSalaryByCompany = employees.GroupBy(e => e.Company)
                                             .Select(g => new { Company = g.Key, AvgSalary = g.Average(e => e.Salary) });
            Console.WriteLine("\n2. Средняя з/п в каждой компании:");
            foreach (var item in avgSalaryByCompany)
                Console.WriteLine($"Компания {item.Company}: {item.AvgSalary:F2}$");

            // 3. Количество сотрудников, владеющих английским
            int knowsEnglishCount = employees.Count(e => e.KnowsEnglish);
            Console.WriteLine($"\n3. Количество сотрудников, владеющих английским: {knowsEnglishCount}");

            // 4. Количество сотрудников с з/п > 3000$
            int highSalaryCount = employees.Count(e => e.Salary > 3000);
            Console.WriteLine($"4. Количество сотрудников с з/п > 3000$: {highSalaryCount}");

            Console.ReadKey();
        }
    }
}