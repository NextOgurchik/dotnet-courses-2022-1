using System;

namespace Task4
{
    internal class Program
    {
        public static int[,] GenerateArray()
        {
           var array = new int[4, 4];
           var rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                }
            }
            return array;
        }
        public static int GetSumOfElementsOnEvenPositions(int [,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }

        public static string PrintArray(int[,] array)
        {
            var s = "Массив:";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                s += "\n";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    s += $"{array[i, j]} ";
                }
            }
            return s;
        }
        static void Main(string[] args)
        {
            var arr = GenerateArray();
            Console.WriteLine(PrintArray(arr));
            Console.WriteLine($"Сумма элементов массива, стоящих на чётных позициях: {GetSumOfElementsOnEvenPositions(arr)}");
        }
    }
}