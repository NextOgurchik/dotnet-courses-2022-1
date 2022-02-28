using System;

namespace ClassLibrary
{
    public class Array2
    {
        private int[,] ArrayItem { get; set; }
        public Array2(int[,] arrayItem)
        {
            ArrayItem = arrayItem;
        }
        public void GenerateArray(int minValue, int maxValue)
        {
            var rnd = new Random();
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                for (int j = 0; j < ArrayItem.GetLength(1); j++)
                {
                    ArrayItem[i,j] = rnd.Next(minValue, maxValue);
                }
            }
        }
        public int GetSumOfElementsOnEvenPositions()
        {
            int sum = 0;
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                for (int j = 0; j < ArrayItem.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += ArrayItem[i, j];
                    }
                }
            }
            return sum;
        }

        public override string ToString()
        {
            var s = "Массив:";
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                s += "\n";
                for (int j = 0; j < ArrayItem.GetLength(1); j++)
                {
                    s += $"{ArrayItem[i, j]} ";
                }
            }
            return s;
        }
    }
}
