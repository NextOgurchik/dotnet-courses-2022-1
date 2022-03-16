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
            double.TryParse(Console.ReadLine(), out double or);
            Console.Write("Введите внутренний радиус: ");
            double.TryParse(Console.ReadLine(), out double ir);
            var p = new Point(x, y);
            var ring = new Ring(p, or, ir);
            ring.Radius = 10;
            Console.WriteLine(ring);
        }
}
