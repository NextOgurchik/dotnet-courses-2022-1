using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public OfficeEventArgs(string name, DateTime time)
        {
            Name = name;
            Time = time;
        }
    }
    internal class Office
    {
        public event EventHandler<OfficeEventArgs> PersonCame;
        public event EventHandler<OfficeEventArgs> PersonLeft;
        public Office()
        {

        }
        public void Come(Person person)
        {
            Console.WriteLine($"{person.Name} пришёл на работу.");
            PersonCame?.Invoke(person, new OfficeEventArgs(person.Name, DateTime.Now));
            PersonCame += person.Greetings;
            PersonLeft += person.Farewell;
        }

        public void Leave(Person person)
        {
            Console.WriteLine($"{person.Name} ушёл с работы.");
            PersonCame -= person.Greetings;
            PersonLeft -= person.Farewell;
            PersonLeft?.Invoke(person, new OfficeEventArgs(person.Name, DateTime.Now));
        }
    }
}
