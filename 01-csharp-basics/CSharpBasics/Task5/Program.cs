using System;

namespace Task5
{
    internal class Program
    {
        private static int SumMultiples3or5(int maxCount)
        {
            int sum = 0;
            for (int i = 1; i < maxCount; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для вывода суммы всех чисел меньше 1000, кратных 3 или 5.");
            Console.WriteLine(SumMultiples3or5(1000));
        }
    }
}
