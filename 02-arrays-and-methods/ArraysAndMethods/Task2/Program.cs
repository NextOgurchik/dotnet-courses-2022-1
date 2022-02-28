using System;
using ClassLibrary;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            Int32.TryParse(Console.ReadLine(), out int x);
            Console.Write("Введите ширину массива: ");
            Int32.TryParse(Console.ReadLine(), out int y);
            Console.Write("Введите глубину массива: ");
            Int32.TryParse(Console.ReadLine(), out int z);
            Console.Write("Введите нижнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b1);
            Console.Write("Введите верхнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b2);
            var arr = new Array3(new int[x, y, z]);
            arr.GenerateArray(b1, b2);
            Console.WriteLine(arr);
            arr.ReplacePositiveElementsWithZero();
            Console.WriteLine(arr);
        }
    }
}
