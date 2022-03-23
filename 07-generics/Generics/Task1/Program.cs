using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var DArr = new DynamicArray<int>(4);
            DArr.Add(1);
            DArr.Add(2);
            DArr.Add(3);
            DArr.Add(4);
            DArr.Insert(7,2);
            DArr.Remove(7);
            DArr.Add(54);
            DArr.Add(65);
            DArr.Add(76);
            DArr.Add(87);
            DArr.Add(98);
            DArr.Insert(666, 0);
            DArr.Insert(666, 5);
            DArr.Insert(666, 5);
            DArr.Insert(666, 5);
            DArr.Insert(666, DArr.Length - 1);
            DArr.Remove(7);
            DArr.Remove(77);
            DArr.AddRange(new int[3] { 10, 11, 12} );
            Console.WriteLine("Length = " + DArr.Length);
            Console.WriteLine("Capacity = " + DArr.Capacity);
            for (int i = 0; i < DArr.Length; i++)
            {
                Console.WriteLine(DArr[i]);
            }
        }
    }
}