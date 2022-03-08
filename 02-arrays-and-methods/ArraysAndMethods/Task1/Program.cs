using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min, max;
            var arr = GenerateArray();
            Console.WriteLine("Массив, заполненый случайными значениями:");
            PrintArray(arr);
            SortAndGetMinAndMaxValues(arr, out min, out max);
            Console.WriteLine("Отсортированный массив:");
            PrintArray(arr);
            Console.WriteLine($"Минимальное значение в массиве: {min}");
            Console.WriteLine($"Максимальное значение в массиве: {max}");
        }
        public static int[] GenerateArray()
        {
            var array = new int[10];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }
            return array;
        }
        public static int[] SortAndGetMinAndMaxValues(int[] array, out int min, out int max)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var value = array[i];
                var j = i;
                while ((j > 0) && (array[j - 1] > value))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
                array[j] = value;
            }
            min = Min(array);
            max = Max(array);
            return array;
        }
        private static void Swap(ref int element1, ref int element2)
        {
            var tmp = element1;
            element1 = element2;
            element2 = tmp;
        }
        public static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        public static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.GetLength(0); i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
