using System;
using ClassLibrary;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            Int32.TryParse(Console.ReadLine(), out int n);
            Console.Write("Введите количество столбцов: ");
            Int32.TryParse(Console.ReadLine(), out int m);
            Console.Write("Введите нижнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b1);
            Console.Write("Введите верхнюю границу случайных чисел: ");
            Int32.TryParse(Console.ReadLine(), out int b2);
            var arr = new Array2(new int[n, m]);
            arr.GenerateArray(b1, b2);
            Console.WriteLine(arr);
            Console.WriteLine($"Сумма элементов массива, стоящих на чётных позициях: {arr.GetSumOfElementsOnEvenPositions()}");
        }
    }
}
