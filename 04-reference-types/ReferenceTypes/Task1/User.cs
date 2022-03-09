using System;

namespace Task1
{
    internal class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        private readonly DateTime _dateOfBirth;
        
        public int Age
        {
            get
            {
                DateTime dt = DateTime.Now;
                int age;
                age = dt.Year - _dateOfBirth.Year;
                if (dt.Month < _dateOfBirth.Month)
                {
                    age--;
                }
                else if (dt.Month == _dateOfBirth.Month)
                {
                    if (dt.Day < _dateOfBirth.Day)
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
