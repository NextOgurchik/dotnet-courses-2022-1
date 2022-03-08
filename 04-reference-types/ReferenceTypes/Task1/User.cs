using System;

namespace Task1
{
    internal class User
    {
        private string name;
        public string Name { get => name; private set { name = string.Empty == value ? value : throw new Exception(); } }
        private string lastName;
        public string LastName { get => lastName; private set { lastName = string.Empty == value ? value : throw new Exception(); } }
        private string patronymic;
        public string Patronymic { get => patronymic; private set { patronymic = string.Empty == value ? value : throw new Exception(); } }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            private set
            {
                dateOfBirth = DateTime.Now >= value ? value : throw new Exception("User hasn't been born yet.");
            }
        }

        public User(DateTime dateOfBirth, string name, string lastName, string patronymic)
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
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
            return $"ФИО: {LastName} {Name} {Patronymic}. Дата рождения: {DateOfBirth:D} Возраст: {Age()}";
        }
    }
}
