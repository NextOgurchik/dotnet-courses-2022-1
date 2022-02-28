using System;
using ClassLibrary;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            Int32.TryParse(Console.ReadLine(), out int n);
            Console.Write("Введите нижнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b1);
            Console.Write("Введите верхнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b2);
            var arr = new Array1(new int[n]);
            arr.GenerateArray(b1, b2);
            Console.WriteLine("Массив, заполненый случайными значениями:");
            Console.WriteLine(arr);
            Console.WriteLine($"Сумма неотрицательных элементов: {arr.GetSumOfNonNegativeElements()}");
        }
    }
}
