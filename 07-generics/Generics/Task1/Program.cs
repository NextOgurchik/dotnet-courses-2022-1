using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var DArr = new DynamicArray<int>();
            DArr.Add(10);
            DArr.Add(21);
            DArr.Add(32);
            DArr.Add(43);
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
            DArr.AddRange(new int[13] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22});
            Console.WriteLine("Length = " + DArr.Length);
            Console.WriteLine("Capacity = " + DArr.Capacity);
            for (int i = 0; i < DArr.Length; i++)
            {
                Console.WriteLine(DArr[i]);
            }
        }
    }
}