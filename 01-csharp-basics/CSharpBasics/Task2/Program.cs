using System;

namespace Task2
{
    internal class Program
    {
        private const char PointChar = '*';
        private static void DrawPoints(int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(PointChar);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int c = 0;
            bool isOk = false;
            Console.WriteLine("Программа для рисования \"изображений\" №1.");
            while (!isOk) 
            {
                Console.Write("Введите количество строк: ");
                isOk = int.TryParse(Console.ReadLine(), out c);
                if (!isOk)
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
                else if (c < 1) 
                {
                    Console.WriteLine("Ошибка! Число должно быть больше 0.");
                    isOk = false;
                }
            }
            DrawPoints(c);
        }
    }
}
