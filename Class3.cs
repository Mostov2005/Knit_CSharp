using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Knit_CSharp
{
    public class Employee
    {
        public string FullName; // Полное имя
        public int YearOfHiring; // Год принятия на работу
        public string Position; // Должность
        public decimal Salary; // ЗП
        public int WorkExperience; // Опыт работы

        public Employee(string fullName, int yearOfHiring, string position, decimal salary, int workExperience)
        {
            FullName = fullName;
            YearOfHiring = yearOfHiring;
            Position = position;
            Salary = salary;
            WorkExperience = workExperience;
        }
    }

    public class Class3
    {
        public void Run()
        {
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\employees.txt"; // Путь к входному файлу
            string outputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\filtered_employees.txt"; // Путь к выходному файлу
            decimal salaryThreshold = 50000m; // Порог зарплаты

            // Чтение сотрудников из файла
            List<Employee> employees = ReadEmployeesFromFile(inputFilePath);

            // foreach (Employee employee in employees){
            //     System.Console.WriteLine(employee.FullName);
            // }


            // Фильтрация сотрудников
            List<Employee> filteredEmployees = FilterEmployeesBySalary(employees, salaryThreshold);

            // Сортировка сотрудников по рабочему стажу
            List<Employee> sortedEmployees = SortEmployeesByExperience(filteredEmployees);

            // Запись в новый файл
            WriteEmployeesToFile(outputFilePath, sortedEmployees);
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

        public static List<Employee> FilterEmployeesBySalary(List<Employee> employees, decimal salaryThreshold)
        {
            return employees.Where(e => e.Salary < salaryThreshold).ToList();
        }

        public static List<Employee> SortEmployeesByExperience(List<Employee> employees)
        {
            return employees.OrderBy(e => e.WorkExperience).ToList();
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