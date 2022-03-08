using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            int r;
            Console.Write("Введите радиус: ");
            int.TryParse(Console.ReadLine(), out r);
            Console.Write("Введите координату X: ");
            int.TryParse(Console.ReadLine(), out x);
            Console.Write("Введите координату Y: ");
            int.TryParse(Console.ReadLine(), out y);
            var p = new Point(x, y);
            var round = new Round(r, p.X, p.Y);
            Console.WriteLine(round);
        }
    }
}