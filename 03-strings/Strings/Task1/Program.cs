﻿using System;

namespace Task1
{
    internal class Program
    {
        private static double AverageWordLength(string text)
        {
            double count = 0;
            var words = text.Split(new char[] { '.', ',', '!', '?', ';', ':', '-', '—', '"', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                count += word.Length;
            }
            if (count == 0) { return 0; }
            return Convert.ToDouble(count / words.Length);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, определяющая среднюю длину слова в тексте");
            Console.Write("Введите текст: ");
            string t = Console.ReadLine();
            Console.WriteLine(AverageWordLength(t));
        }
    }
}
