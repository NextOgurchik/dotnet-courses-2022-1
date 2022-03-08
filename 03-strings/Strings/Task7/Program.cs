using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static int TimeFinder(string text)
        {
            int c = 0;
            Regex regex = new Regex(@"(([ ,0,1][0-9])|(2[0-3])):[ ,0-5][0-9]");
            var matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    c++;
                }
            }
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая определяет, сколько раз в тексте встречается время");
            string s = "В 7:55 я встал, позавтракал и к 10:77 пошел на 00:24 00:60 06:00 6:00 14:00 14:60 14:06 25:00 работу.";
            Console.WriteLine("Исходный текст:\n" + s);
            Console.WriteLine("Время встречается в тексте " + TimeFinder(s) + " раз");
        }
    }
}