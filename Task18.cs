using System;

namespace Knit_CSharp
{
    class Task18
    {
        public void Run()
        {
            string filePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\input_for_18.txt";
            var persons = new List<Person>();

            // Чтение данных из файла
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(' ');
                if (parts[0] == "Абитуриент")
                    persons.Add(new Applicant(parts[1], DateTime.Parse(parts[2]), parts[3]));
                else if (parts[0] == "Студент")
                    persons.Add(new Student(parts[1], DateTime.Parse(parts[2]), parts[3], int.Parse(parts[4])));
                else if (parts[0] == "Преподаватель")
                    persons.Add(new Teacher(parts[1], DateTime.Parse(parts[2]), parts[3], parts[4], int.Parse(parts[5])));
            }

            string outputFilePath = "C:\\Users\\Mostov\\Knit_CSharp\\System_File\\output_for_18.txt";
            using (var writer = new StreamWriter(outputFilePath))
            {
                Console.SetOut(writer); // Перенаправление вывода в файл

                // Вывод полной информации о базе
                Console.WriteLine("Полная информация о базе:");
                persons.ForEach(person => Console.WriteLine(person.ToString()));

                int minAge = 12;
                int maxAge = 100;

                System.Console.WriteLine();
                Console.WriteLine($"Люди с возрастом от {minAge} до {maxAge}:");
                persons.Where(person => person.GetAge() >= minAge && person.GetAge() <= maxAge)
                       .ToList().ForEach(person => Console.WriteLine(person));

                // Сортировка базы данных по дате рождения
                persons.Sort((x, y) => x.CompareTo(y));
                System.Console.WriteLine();
                Console.WriteLine("База данных после сортировки по дате рождения:");
                persons.ForEach(person => Console.WriteLine(person));

            }
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
}
