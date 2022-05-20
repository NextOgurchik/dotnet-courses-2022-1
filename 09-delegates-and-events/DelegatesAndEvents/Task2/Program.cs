using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var office = new Office();
            var person1 = new Person("Джон");
            var person2 = new Person("Билл");
            var person3 = new Person("Хьюго");

            office.Come(person1);
            Console.WriteLine();

            office.Come(person2);
            Console.WriteLine();

            office.Come(person3);
            Console.WriteLine();

            office.Leave(person1);
            Console.WriteLine();

            office.Leave(person2);
            Console.WriteLine();

            office.Leave(person3);
        }
    }
}
