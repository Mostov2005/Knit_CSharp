using System.Text.Json.Serialization;


namespace Knit_CSharp
{
    // Класс Абитуриент
    public class Applicant : Person, IApplicant
    {
        public string Faculty { get; set; }

        [JsonConstructor]
        public Applicant(string lastName, DateTime birthDate, string faculty)
            : base(lastName, birthDate)
        {
            this.Faculty = faculty;
        }

        public override string ToString()
        {
            return $"Абитуриент: {LastName}, " +
                   $"Дата рождения: {BirthDate.ToShortDateString()}, " +
                   $"Факультет: {Faculty}, " +
                   $"Возраст: {GetAge()}";
        }
    }
}
