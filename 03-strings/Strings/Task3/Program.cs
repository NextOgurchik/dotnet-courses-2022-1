using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task3
{
    internal class Program
    {
        private static void СulturesDiff(CultureInfo culture1, CultureInfo culture2)
        {
            var localDate = DateTime.Now;
            var doubleNumber = 3.14;
            var intNumber = 999999999;
            Console.WriteLine($"{culture1.NativeName,-50}" +
                $"{culture2.NativeName}");
            Console.WriteLine($"{localDate.ToString(culture1),-50}" +
                $"{localDate.ToString(culture2)}");
            Console.WriteLine($"{doubleNumber.ToString(culture1),-50}" +
                $"{doubleNumber.ToString(culture2)}");
            Console.WriteLine($"{intNumber.ToString("N", culture1),-50}" +
                $"{intNumber.ToString("N", culture2)}");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Программа, которая выводит на экран отличия в параметрах культур (ru, en, invariant)");
            Console.Write("Введите первый формат: ");
            string c1 = Console.ReadLine();
            Console.Write("Введите второй формат: ");
            string c2 = Console.ReadLine();
            var cultureName = new Dictionary<string, string>(3)
            {
                { "en", "en-US" },
                { "ru", "ru-RU" },
                { "invariant", string.Empty },
                { "", string.Empty }
            };
            var cultureInfo1 = new CultureInfo(cultureName[c1]);
            var cultureInfo2 = new CultureInfo(cultureName[c2]);
            СulturesDiff(cultureInfo1, cultureInfo2);
        }
    }
}
