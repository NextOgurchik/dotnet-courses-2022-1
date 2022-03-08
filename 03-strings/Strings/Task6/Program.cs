using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void NumberType(string text)
        {
            Regex regex1 = new Regex(@"[-]?\d+[,|.]?\d*[e]{1}\d+");
            Regex regex2 = new Regex(@"[-]?\d+[,|.]?\d*");

            var matches1 = regex1.Matches(text);
            var matches2 = regex2.Matches(text);

            if (matches1.Count > 0)
            {
                foreach (Match match in matches1)
                {
                    Console.WriteLine(match);
                    Console.WriteLine("Это число в научной нотации");
                }
            }
            else if (matches2.Count > 0)
            {
                foreach (Match match in matches2)
                {
                    Console.WriteLine(match);
                    Console.WriteLine("Это число в обычной нотации");
                }
            }
            else
            {
                Console.WriteLine("Число не было введено");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для определения формата записи чисел");
            Console.Write("Введите число: ");
            string s = Console.ReadLine();
            NumberType(s);
        }
    }
}
