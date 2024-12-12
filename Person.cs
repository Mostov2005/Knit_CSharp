namespace Knit_CSharp
{
    public abstract class Person : IComparable<Person>
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        protected Person(string lastName, DateTime birthDate)
        {
            LastName = lastName;
            BirthDate = birthDate;
        }

        // Метод для определения возраста
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }

        // Реализация метода CompareTo для сортировки по дате рождения
        public int CompareTo(Person other)
        {
            if (other == null) return 1; // Если другой объект null, текущий объект считается больше
            return BirthDate.CompareTo(other.BirthDate);
        }

    }
}
