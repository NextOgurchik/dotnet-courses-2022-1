using System;

namespace Task1
{
    class Program
    {
        public static int[] Method(int[] arr)
        {
            int col = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0) { col++; }
            }
            var arr2 = new int[col];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0) { arr2[j] = arr[i]; j++; }
            }
            return arr2;
        }
        static void Main()
        {
            var a = new int[5];
            a[0] = 1;
            a[1] = -2;
            a[2] = 0;
            a[3] = -4;
            a[4] = 5;
            var b = Method(a);
            foreach (var x in b)
            {
                Console.WriteLine(x);
            }
        }
    }
}