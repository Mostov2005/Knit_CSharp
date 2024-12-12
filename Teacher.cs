namespace Knit_CSharp
{
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

        public override string ToString()
        {
            return $"Преподаватель: {LastName}, " +
                   $"Дата рождения: {BirthDate.ToShortDateString()}, " +
                   $"Факультет: {Faculty}, " +
                   $"Должность: {Position}, " +
                   $"Стаж: {Experience}, " +
                   $"Возраст: {GetAge()}";
        }
    }
}
