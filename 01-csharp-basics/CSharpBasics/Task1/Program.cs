using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0;
            bool isOk = false;
            Console.WriteLine("Программа для нахождения площади прямоугольника.");
            while (!isOk)
            {
                Console.Write("Введите длину одной стороны прямоугольника: ");
                if (int.TryParse(Console.ReadLine(), out a))
                {
                    if (a > 0)
                    {
                        while (b < 1)
                        {
                            Console.Write("Введите длину другой стороны прямоугольника: ");
                            if (int.TryParse(Console.ReadLine(), out b))
                            {
                                if (b > 0)
                                {
                                    isOk = true;
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка! Число должно быть больше 0.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Введите корректное число.");
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Число должно быть больше 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }
            }

            var rect = new Rectangle(a, b);
            var s = rect.Width > 0 && rect.Height > 0 ? $"{rect.Area()}"
                : "Ошибка! Все стороны прямоугольника должны быть больше 0.";
            Console.WriteLine(s);
        }
    }
}
