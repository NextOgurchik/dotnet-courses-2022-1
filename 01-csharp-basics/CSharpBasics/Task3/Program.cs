using System;

namespace Task3
{
    internal class Program
    {
        private const char PointChar = '*';
        private static void DrawPoints(int rowCount)
        {
            int charCount = 1;
            for (int i = 0; i < rowCount; i++)
            {
                for (int l = 0; l < rowCount-i-1; l++)
                {
                    Console.Write(' ');
                }
                for (int j = 0; j < charCount; j++)
                {
                    Console.Write(PointChar);
                }
                Console.WriteLine();
                charCount += 2;
            }
        }
        static void Main(string[] args)
        {
            int c = 0;
            bool isOk = false;
            Console.WriteLine("Программа для рисования \"изображений\" №2");
            while (!isOk) 
            {
                Console.Write("Введите количество строк: ");
                isOk = Int32.TryParse(Console.ReadLine(), out c);
                if (!isOk)
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
                if (c < 1 && isOk)
                {
                    Console.WriteLine("Ошибка! Число должно быть больше 0.");
                    isOk = false;
                }
            }
            DrawPoints(c);
        }
    }
}
