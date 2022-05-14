using System;

namespace Task2
{
    internal class Employee : User, IEquatable<Employee>
    {
        private DateTime dateOfHiring;
        public DateTime DateOfHiring
        {
            get { return dateOfHiring; }
            set
            {
                if (value > DateTime.Now || value < DateOfBirth)
                {
                    throw new Exception("Work experience is longer than employee's term of work or employee was hired before he was born");
                }
                dateOfHiring = value;
            }
        }
        public int Experience => DateTime.Now.Year - DateOfHiring.Year;
        public string Position { get; set; }

        public Employee(string firstName, string lastName, string pastronymic, DateTime dateOfBirth, DateTime dateOfHiring, string position)
            : base(firstName, lastName, pastronymic, dateOfBirth)
        {
            DateOfHiring = dateOfHiring;
            Position = position;
        }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {Pastronymic}. Дата рождения: {DateOfBirth:D} Возраст: {GetAge()}. " +
                $"Стаж работы (лет): {Experience}. Должность: {Position}.";
        }

        public bool Equals(Employee other)
        {
            if (FirstName == other.FirstName
            && LastName == other.LastName && Pastronymic == other.Pastronymic
            && DateOfBirth == other.DateOfBirth)
            {
                return true;
            }
            return false;
        }
    }
}
