using System;

namespace EmployeeLib
{
    public class Employee
    {
        public string Company { get; set; }  // Компания (1-4 как string)
        public double Salary { get; set; }   // Зарплата
        public bool KnowsEnglish { get; set; }  // Знает ли английский

        public Employee(string company, double salary, bool knowsEnglish)
        {
            Company = company;
            Salary = salary;
            KnowsEnglish = knowsEnglish;
        }
    }
}