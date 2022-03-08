using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void RemoveTags(ref string text)
        {
            Regex regex = new Regex(@"\<(/?[^\>]+)\>");
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                text = text.Replace(match.Value, "_");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, которая заменяет все найденные в тексте HTML теги на знак “_”");
            string s = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами";
            Console.WriteLine("Исходный текст: " + s);
            RemoveTags(ref s);
            Console.WriteLine("Текст без тегов: " + s);
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
