using System;

namespace Task2
{
    internal class Program
    {
        public static int[,,] GenerateArray()
        {
            var array = new int[3,3,3];
            var rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = rnd.Next(-10, 10);
                    }
                }
            }
            return array;
        }
        public static void ReplacePositiveElementsWithZero(int [,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }
        public static string PrintArray(int[,,] array)
        {
            var s = "Массив:";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                s += "\n";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    s += "{ ";
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        s += $"{array[i, j, k]} ";
                    }
                    s += "} ";
                }
            }
            return s;
        }
        static void Main(string[] args)
        {
            var arr = GenerateArray();
            Console.WriteLine(PrintArray(arr));
            ReplacePositiveElementsWithZero(arr);
            Console.WriteLine(PrintArray(arr));
        }
    }
}
