using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите координату X: ");
            int.TryParse(Console.ReadLine(), out int x);
            Console.Write("Введите координату Y: ");
            int.TryParse(Console.ReadLine(), out int y);
            Console.Write("Введите внешний радиус: ");
            int.TryParse(Console.ReadLine(), out int or);
            Console.Write("Введите внутренний радиус: ");
            int.TryParse(Console.ReadLine(), out int ir);
            var p = new Point(x, y);
            var ring = new Ring(or, ir, p.X, p.Y);
            ring.Radius = 10;
            Console.WriteLine(ring);
        }
    }
}
