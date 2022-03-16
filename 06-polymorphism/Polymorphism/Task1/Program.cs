using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var figure = new List<Figure>
            {
                 new Figure(new Point(1, 0)),
                 new Ring(new Point(2, 1), 5, 3),
                 new Сircle(new Point(2, 2), 3),
                 new Round(new Point(5, 5), 6),
                 new Rectangle(new Point(1, 0),new Point(1, 0))
            };

            foreach (var fig in figure)
            {
                Console.WriteLine(fig.Draw());
            }
        }
    }
}
