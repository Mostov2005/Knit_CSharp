using System;

namespace Knit_CSharp
{
    class Task18
    {
        public void Run()
        {
            // 3. Создание базы данных персон
            Person[] persons = new Person[]
            {
                new Applicant("Иванов", new DateTime(2007, 1, 1), "Физический"),
                new Applicant("Иванов", new DateTime(2006, 5, 15), "КНИИТ"),

                new Student("Петров", new DateTime(2004, 2, 10), "Химический", 2),
                new Student("Петров", new DateTime(2005, 9, 22), "КНИИТ", 2),

                new Teacher("Сидоров", new DateTime(1980, 3, 25), "Математический", "Доцент", 15),
                new Teacher("Сидоров", new DateTime(1970, 1, 13), "КНИИТ", "Доцент", 15)
            };

            // Вывод информации о всех персонах
            Console.WriteLine("Полная информация о базе:");
            foreach (var person in persons)
            {
                person.PrintInfo();
            }

            // Организация поиска персон по возрасту
            Console.WriteLine("Введите минимальный возраст:");
            int minAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальный возраст:");
            int maxAge = int.Parse(Console.ReadLine());

            Console.WriteLine($"Персоны с возрастом от {minAge} до {maxAge}:");
            foreach (var person in persons)
            {
                int age = person.GetAge();
                if (age >= minAge && age <= maxAge)
                {
                    person.PrintInfo();
                }
            }

            //Teacher a = new Teacher("Сидоров", new DateTime(1970, 1, 13), "КНИИТ", "Доцент", 15);
            // System.Console.WriteLine(a.Position);
        }
    }
    // Базовый класс Персона
    public abstract class Person
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        protected Person(string lastName, DateTime birthDate)
        {
            LastName = lastName;
            BirthDate = birthDate;
        }

        // Метод для вывода информации
        public abstract void PrintInfo();

        // Метод для определения возраста
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }
    }

    // Интерфейс для абитуриента
    public interface IApplicant
    {
        string Faculty { get; set; }
    }

    // Интерфейс для студента
    public interface IStudent
    {
        int Course { get; set; }
    }

    // Интерфейс для преподавателя
    public interface ITeacher
    {
        string Position { get; set; }
        int Experience { get; set; }

    }

    // Класс Абитуриент
    public class Applicant : Person, IApplicant
    {
        public string Faculty { get; set; }

        public Applicant(string lastName, DateTime birthDate, string faculty)
            : base(lastName, birthDate)
        {
            this.Faculty = faculty;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Абитуриент: {LastName}, " +
                              $"Дата рождения: {BirthDate.ToShortDateString()}, " +
                              $"Факультет: {Faculty}, " +
                              $"Возраст: {GetAge()}");
        }
    }

    // Класс Студент
    public class Student : Person, IApplicant, IStudent
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        public Student(string lastName, DateTime birthDate, string faculty, int course)
            : base(lastName, birthDate)
        {
            this.Faculty = faculty;
            this.Course = course;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Студент: {LastName} " +
             $"Дата рождения: {BirthDate.ToShortDateString()} " +
             $"Факультет: {Faculty} " +
             $"Курс: {Course} " +
             $"Возраст: {GetAge()} ");
        }
    }

    // Класс Преподаватель
    public class Teacher : Person, IApplicant, ITeacher
    {
        public string Faculty { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }

        public Teacher(string lastName, DateTime birthDate, string faculty, string position, int experience)
            : base(lastName, birthDate)
        {
            this.Faculty = faculty;
            this.Position = position;
            this.Experience = experience;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Преподаватель: {LastName}, " +
                              $"Дата рождения: {BirthDate.ToShortDateString()}, " +
                              $"Факультет: {Faculty}, " +
                              $"Должность: {Position}, " +
                              $"Стаж: {Experience}, " +
                              $"Возраст: {GetAge()}");
        }
    }
}
