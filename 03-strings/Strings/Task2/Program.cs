using System;

namespace Task2
{
    class Program
    {
        private static string DoublingCharacters(string text1, string text2)
        {
            string text3 = "";
            for (int i = 0; i < text1.Length; i++)
            {
                text3 += text1[i];
                for (int j = 0; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        text3 += text2[j];
                        break;
                    }
                }
            }
            return text3;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа, удваивающая символы текста 1, если они содержатся в тексте 2");
            Console.Write("Введите первую строку: ");
            string s1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Текст 1: " + s1 + "\nТекст 2: " + s2);
            Console.WriteLine(DoublingCharacters(s1, s2));
        }
    }
}
