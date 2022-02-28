using System;

namespace Task4
{
    internal class Program
    {
        private const char PointChar = '*';
        private static void DrawPoints(int triangleCount)
        {
            for (int i = 1; i <= triangleCount; i++)//Треугольники
            {
                int charCount = 1;
                for (int j = 0; j < i; j++)//Строки
                {
                    Console.CursorLeft = triangleCount - j;
                    for (int k = 0; k < charCount; k++)//Символы
                    {
                        Console.Write(PointChar);
                    }
                    Console.WriteLine();
                    charCount += 2;
                }
            }
        }
        static void Main(string[] args)
        {
            int c = 0;
            bool isOk = false;
            Console.WriteLine("Программа для рисования \"изображений\" №3");
            while (!isOk)
            {
                Console.Write("Введите количество треугольников: ");
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
