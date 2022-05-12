using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var worker = new Employee("Иван", "Иванов", "Иванович", new DateTime(1990, 10, 1), new DateTime(2014, 10, 1), "Директор");
            var worker2 = new Employee("Иван", "Иванов", "Иванович", new DateTime(1990, 10, 1), new DateTime(2014, 10, 1), "Директор");
            Console.WriteLine(worker.Equals(worker2));
        }
    }
}