using System;

namespace Task3
{
    internal class Program
    {
        public static int[] GenerateArray()
        {
            var array = new int[10];
            var rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = rnd.Next(-10, 10);
            }
            return array;
        }
        public static int GetSumOfNonNegativeElements(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        public static string PrintArray(int[] array)
        {
            var s = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                s += $"{array[i]}\n";
            }
            return s;
        }

        static void Main(string[] args)
        {
            var arr = GenerateArray();
            Console.WriteLine("Массив, заполненый случайными значениями:");
            Console.WriteLine(PrintArray(arr));
            Console.WriteLine($"Сумма неотрицательных элементов: {GetSumOfNonNegativeElements(arr)}");
        }
    }
}
