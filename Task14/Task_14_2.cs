using System;
using System.IO;

namespace Knit_CSharp
{
    public struct Employee : IComparable<Employee>
    {
        public string FullName; // Имя
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

        // Реализация CompareTo для сортировки по рабочему стажу
        public int CompareTo(Employee other)
        {
            return -this.WorkExperience.CompareTo(other.WorkExperience);
        }
    }

    public class Task_14_2
    {
        public void Run()
        {
            string inputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\employees(14_2).txt";
            string outputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\filtered_employees_14_2.txt"; // Путь к выходному файлу
            decimal salaryThreshold = 70000m; // Порог зарплаты

            // Чтение сотрудников из файла
            Employee[] employees = ReadEmployeesFromFile(inputFilePath);

            // Фильтрация сотрудников по зарплате
            //Employee[] filteredEmployees = Array.FindAll(employees, e => e.Salary < salaryThreshold);

            List<Employee> tempEmployees = new List<Employee>();

            foreach (var employee in employees)
            {
                if (employee.Salary < salaryThreshold)
                {
                    tempEmployees.Add(employee);
                }
            }

            // Преобразуем список в массив
            Employee[] filteredEmployees = tempEmployees.ToArray();


            // Сортировка сотрудников по рабочему стажу
            Array.Sort(filteredEmployees);

            // Запись результата в файл
            WriteEmployeesToFile(outputFilePath, filteredEmployees);
        }

        public static Employee[] ReadEmployeesFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Employee[] employees = new Employee[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length == 5)
                {
                    string fullName = parts[0];
                    int yearOfHiring = int.Parse(parts[1]);
                    string position = parts[2];
                    decimal salary = decimal.Parse(parts[3]);
                    int workExperience = int.Parse(parts[4]);

                    employees[i] = new Employee(fullName, yearOfHiring, position, salary, workExperience);
                }
            }
            return employees;
        }

        public static void WriteEmployeesToFile(string filePath, Employee[] employees)
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
