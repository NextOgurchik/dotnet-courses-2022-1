using System;

namespace Task1
{
    internal class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        private readonly DateTime _dateOfBirth;
        private int age;
        public int Age
        {
            get
            {
                age = DateTime.Now.Year - _dateOfBirth.Year;
                if (DateTime.Now.Month < _dateOfBirth.Month)
                {
                    age--;
                }
                else if (DateTime.Now.Month == _dateOfBirth.Month)
                {
                    if (DateTime.Now.Day < _dateOfBirth.Day)
                    {
                        age--;
                    }
                }
                return age;
            }
        }

        public User(DateTime dateOfBirth, string name, string lastName, string patronymic)
        {
            _dateOfBirth = DateTime.Now >= dateOfBirth ? dateOfBirth : throw new Exception("User hasn't been born yet.");
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
        }
        
        public override string ToString()
        {
            return $"ФИО: {LastName} {Name} {Patronymic}. Дата рождения: {_dateOfBirth:D} Возраст: {Age}";
        }
    }
}
