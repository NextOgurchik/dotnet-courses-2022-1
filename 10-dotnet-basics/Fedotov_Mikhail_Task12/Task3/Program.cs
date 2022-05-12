using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {

        static void Main(string[] args)
        {
            var a = new TwoDPointWithHash(1, 1);
            var b = new TwoDPointWithHash(10, 10);
            var c = new TwoDPointWithHash(1, 10);
            var d = new TwoDPointWithHash(10, 1);
            Console.WriteLine(Convert.ToString(a.GetHashCode()));
            Console.WriteLine(Convert.ToString(b.GetHashCode()));
            Console.WriteLine(Convert.ToString(c.GetHashCode()));
            Console.WriteLine(Convert.ToString(d.GetHashCode()));
        }
    }
}
