using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void NumberType(string text)
        {
            Regex regex1 = new Regex(@"[-]?\d+[,.]?\d*[eE]\d+");
            Regex regex2 = new Regex(@"^[-]?\d+([,.]\d+)?$");

            if (regex1.IsMatch(text))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else if (regex2.IsMatch(text))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
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
