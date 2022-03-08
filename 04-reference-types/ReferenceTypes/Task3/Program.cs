using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Введите сторону a: ");
            int.TryParse(Console.ReadLine(), out a);
            Console.Write("Введите сторону b: ");
            int.TryParse(Console.ReadLine(), out b);
            Console.Write("Введите сторону c: ");
            int.TryParse(Console.ReadLine(), out c);
            var tr = new Triangle(a, b, c);
            Console.WriteLine(tr);
        }
    }
}
