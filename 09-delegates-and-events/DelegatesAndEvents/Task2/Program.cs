using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        static List<Person> persons;
        static void Main(string[] args)
        {
            persons = new List<Person>()
            {
                new Person("Лёша"),
                new Person("Ваня"),
                new Person("Серёжа"),
            };
            foreach (var person in persons)
            {
                person.Arrived += Employee_ArrivedToOffice;
                person.Left += Employee_LeftOffice;
            }
            Console.WriteLine("Лёша пришёл");
            persons[0].CheckIn();
            Console.WriteLine("Ваня пришёл");
            persons[1].CheckIn();
            Console.WriteLine("Серёжа пришёл");
            persons[2].CheckIn();
            Console.WriteLine("Лёша ушёл");
            persons[0].CheckOut();
            Console.WriteLine("Ваня ушёл");
            persons[1].CheckOut();
            Console.WriteLine("Серёжа ушёл");
            persons[2].CheckOut();
        }
        private static void Employee_ArrivedToOffice(object sender, PersonEventArgs args)
        {
            var list = persons
                .Where(e => e.AtWork && e.Name != args.Name)
                .OrderBy(e => e.TimeIn);

            if (list.Count() == 0)
            {
                Console.WriteLine("Никто не работает");
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.Greetings(args.Name, args.Time));
            }
        }
        private static void Employee_LeftOffice(object sender, PersonEventArgs args)
        {
            var list = persons
               .Where(e => e.AtWork && e.Name != args.Name)
               .OrderBy(e => e.TimeIn);

            if (list.Count() == 0)
            {
                Console.WriteLine("Никто не работает");
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.Farewell(args.Name));
            }
        }
    }
}
