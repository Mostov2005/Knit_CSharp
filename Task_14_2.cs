using System;
using System.Collections.Generic;
using System.IO;

namespace Knit_CSharp
{
    public struct Employee
    {
        public string FullName; // Полное имя
        public int YearOfHiring; // Год принятия на работу
        public string Position; // Должность
        public decimal Salary; // ЗП
        public int WorkExperience; // Опыт работы

        public Employee(string fullName, int yearOfHiring, string position, decimal salary, int workExperience)
        {
            this.FullName = fullName;
            this.YearOfHiring = yearOfHiring;
            this.Position = position;
            this.Salary = salary;
            this.WorkExperience = workExperience;
        }
    }

    public class Task_14_2
    {
        public void Run()
        {
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\employees(14_2).txt"; // Путь к входному файлу
            string outputFilePathLinq = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\filtered_employees_linq(14_2).txt"; // Путь для LINQ
            string outputFilePathNoLinq = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\filtered_employees_no_linq(14_2).txt"; // Путь для циклов
            decimal salaryThreshold = 50000m; // Порог зарплаты

            // Чтение сотрудников из файла
            List<Employee> employees = ReadEmployeesFromFile(inputFilePath);

            var filteredAndSortedLinq = 
                (from employee in employees
                 where employee.Salary < salaryThreshold
                 orderby employee.WorkExperience //  descending // - для сортировки в обратном порядке
                 select employee).ToList();

            // Запись результата LINQ в файл
            WriteEmployeesToFile(outputFilePathLinq, filteredAndSortedLinq);

            List<Employee> filteredEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee.Salary < salaryThreshold)
                {
                    filteredEmployees.Add(employee);
                }
            }

            // Сортировка
            for (int i = 0; i < filteredEmployees.Count - 1; i++)
            {
                for (int j = 0; j < filteredEmployees.Count - i - 1; j++)
                {
                    if (filteredEmployees[j].WorkExperience > filteredEmployees[j + 1].WorkExperience)
                    {
                        var temp = filteredEmployees[j];
                        filteredEmployees[j] = filteredEmployees[j + 1];
                        filteredEmployees[j + 1] = temp;
                    }
                }
            }

            // Запись результата без LINQ в файл
            WriteEmployeesToFile(outputFilePathNoLinq, filteredEmployees);
        }

        public static List<Employee> ReadEmployeesFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 5)
                {
                    string fullName = parts[0];
                    int yearOfHiring = int.Parse(parts[1]);
                    string position = parts[2];
                    decimal salary = decimal.Parse(parts[3]);
                    int workExperience = int.Parse(parts[4]);

                    Employee employee = new Employee(fullName, yearOfHiring, position, salary, workExperience);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public static void WriteEmployeesToFile(string filePath, List<Employee> employees)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var employee in employees)
                {
                    writer.WriteLine($"{employee.FullName};{employee.YearOfHiring};{employee.Position};{employee.Salary};{employee.WorkExperience}");
                }
            }
        }
    }
}
