using System;

namespace Task1
{
    internal class Employee : User
    {
        private int experience;
        public int Experience
        {
            get { return experience; }
            set
            {
                if (DateTime.Now.Year - DateOfBirth.Year > value && value >= 0)
                {
                    experience = value;
                }
                else
                {
                    throw new Exception("Work experience is longer than employee's age or less than zero.");
                }
            }
        }
        public string Position { get; set; }

        public Employee(string firstName, string lastName, string pastronymic, DateTime dateOfBirth, int experience, string position)
            : base(firstName, lastName, pastronymic, dateOfBirth)
        {
            Experience = experience;
            Position = position;
        }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {Pastronymic}. Дата рождения: {DateOfBirth:D} Возраст: {GetAge()}. " +
                $"Стаж работы (лет): {Experience}. Должность: {Position}.";
        }
    }
}
