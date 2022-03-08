using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.Write("Введите сторону a: ");
            Double.TryParse(Console.ReadLine(), out a);
            Console.Write("Введите сторону b: ");
            Double.TryParse(Console.ReadLine(), out b);
            Console.Write("Введите сторону c: ");
            Double.TryParse(Console.ReadLine(), out c);
            var tr = new Triangle(a, b, c);
            Console.WriteLine(tr);
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
