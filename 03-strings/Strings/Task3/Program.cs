using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task3
{
    internal class Program
    {
        private static void СulturesDiff(string culture1, string culture2)
        {
            var cultureName = new Dictionary<string, string>(3)
            {
                { "en", "en-US" },
                { "ru", "ru-RU" },
                { "invariant", String.Empty }
            };
            var cultureInfo1 = new CultureInfo(cultureName[culture1]);
            var cultureInfo2 = new CultureInfo(cultureName[culture2]);

            var localDate = DateTime.Now;
            var doubleNumber = 3.14;
            var intNumber = 999999999;
            Console.WriteLine($"{cultureInfo1.NativeName,-50}" +
                $"{cultureInfo2.NativeName}");
            Console.WriteLine($"{localDate.ToString(cultureInfo1),-50}" +
                $"{localDate.ToString(cultureInfo2)}");
            Console.WriteLine($"{doubleNumber.ToString(cultureInfo1),-50}" +
                $"{doubleNumber.ToString(cultureInfo2)}");
            Console.WriteLine($"{intNumber.ToString("N", cultureInfo1),-50}" +
                $"{intNumber.ToString("N", cultureInfo2)}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая выводит на экран отличия в параметрах культур (ru, en, invariant)");
            Console.Write("Введите первый формат: ");
            string c1 = Console.ReadLine();
            Console.Write("Введите второй формат: ");
            string c2 = Console.ReadLine();
            СulturesDiff(c1, c2);
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
