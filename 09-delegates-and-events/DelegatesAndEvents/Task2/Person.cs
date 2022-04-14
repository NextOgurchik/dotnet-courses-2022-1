using System;

namespace Task2
{
    public class PersonEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public string Name { get; set; }

        public PersonEventArgs(DateTime time, string name)
        {
            Time = time;
            Name = name;
        }
    }
    public delegate void PersonEventHandler(object sender, PersonEventArgs args);
    class Person
    {
        public event PersonEventHandler Arrived;
        public event PersonEventHandler Left;
        protected virtual void OnArrived(object sender, PersonEventArgs args)
        {
            Arrived?.Invoke(sender, args);
        }
        protected virtual void OnLeft(object sender, PersonEventArgs args)
        {
            Left?.Invoke(sender, args);
        }
        public string Name { get; set; }
        public DateTime TimeIn { get; private set; }
        public bool AtWork { get; private set; }
        public Person(string name)
        {
            Name = name;
        }
        public void CheckIn()
        {
            AtWork = true;
            TimeIn = DateTime.Now;
            Arrived(this, new PersonEventArgs(TimeIn, Name));
        }

        public void CheckOut()
        {
            AtWork = false;
            TimeIn = DateTime.MinValue;
            Left(this, new PersonEventArgs(TimeIn, Name));
        }
        public string Greetings(string name, DateTime dateTime)
        {
            if (dateTime.Hour < 12)
            {
                return $"Доброе утро, {name}! - сказал {Name}";
            }
            else if (dateTime.Hour >= 12 && dateTime.Hour <= 17)
            {
                return $"Добрый день, {name}! - сказал {Name}";
            }
            else
            {
                return $"Добрый вечер, {name}! - сказал {Name}";
            }
        }

        public string Farewell(string name)
        {
            return $"До свидания, {name}! - сказал {Name}";
        }
    }
}
