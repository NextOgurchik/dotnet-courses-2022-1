using System;

namespace ClassLibrary
{
    public class Array1
    {
        private int[] ArrayItem { get; set; }
        public Array1(int[] arrayItem)
        {
            ArrayItem = arrayItem;
        }
        public void GenerateArray(int minValue, int maxValue)
        {
            var rnd = new Random();
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                ArrayItem[i] = rnd.Next(minValue, maxValue);
            }
        }
        private void Swap(ref int element1, ref int element2)
        {
            var tmp = element1;
            element1 = element2;
            element2 = tmp;
        }

        public void SortAndGetMinAndMaxValues(out int min, out int max)
        {
            for (int i = 1; i < ArrayItem.GetLength(0); i++)
            {
                var value = ArrayItem[i];
                var j = i;
                while ((j > 0) && (ArrayItem[j - 1] > value))
                {
                    Swap(ref ArrayItem[j - 1], ref ArrayItem[j]);
                    j--;
                }
                ArrayItem[j] = value;
            }
            min = Min();
            max = Max();
        }

        public int Min()
        {
            int min = ArrayItem[0];
            for (int i = 1; i < ArrayItem.GetLength(0); i++)
            {
                if (ArrayItem[i] < min)
                {
                    min = ArrayItem[i];
                }
            }
            return min;
        }

        public int Max()
        {
            int max = ArrayItem[0];
            for (int i = 1; i < ArrayItem.GetLength(0); i++)
            {
                if (ArrayItem[i] > max)
                {
                    max = ArrayItem[i];
                }
            }
            return max;
        }

        public int GetSumOfNonNegativeElements()
        {
            int sum = 0;
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                if (ArrayItem[i] > 0)
                {
                    sum += ArrayItem[i];
                }
            }
            return sum;
        }
        public override string ToString()
        {
            var s = "";
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                s += $"{ArrayItem[i]}\n";
            }
            return s;
        }
    }
}
