using System;

namespace Task1
{
    internal class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pastronymic { get; set; }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            private set
            {
                dateOfBirth = DateTime.Now >= value ? value : throw new Exception("User hasn't been born yet.");
            }
        }

        public User(DateTime dateOfBirth, string firstName, string lastName, string pastronymic)
        {
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            Pastronymic = pastronymic;
        }

        public int Age()
        {
            int a = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month)
            {
                a--;
            }
            else if (DateTime.Now.Month == DateOfBirth.Month)
            {
                if (DateTime.Now.Day < DateOfBirth.Day)
                {
                    a--;
                }
            }
            return a;
        }
        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {Pastronymic}. Дата рождения: {DateOfBirth:D} Возраст: {Age()}";
        }
    }
}
