namespace Knit_CSharp
{
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

        public override string ToString()
        {
            return $"Студент: {LastName}, " +
                   $"Дата рождения: {BirthDate.ToShortDateString()}, " +
                   $"Факультет: {Faculty}, " +
                   $"Курс: {Course}, " +
                   $"Возраст: {GetAge()}";
        }
    }
}
