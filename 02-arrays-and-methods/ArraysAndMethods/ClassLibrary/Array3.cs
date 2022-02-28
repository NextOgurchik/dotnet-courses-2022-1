using System;

namespace ClassLibrary
{
    public class Array3
    {
        private int[,,] ArrayItem { get; set; }
        public Array3(int[,,] arrayItem)
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
                    for (int k = 0; k < ArrayItem.GetLength(2); k++)
                    {
                        ArrayItem[i, j, k] = rnd.Next(minValue, maxValue);
                    }
                }
            }
        }
        public void ReplacePositiveElementsWithZero()
        {
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                for (int j = 0; j < ArrayItem.GetLength(1); j++)
                {
                    for (int k = 0; k < ArrayItem.GetLength(2); k++)
                    {
                        if (ArrayItem[i, j, k] > 0)
                        {
                            ArrayItem[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var s = "Массив:";
            for (int i = 0; i < ArrayItem.GetLength(0); i++)
            {
                s += "\n";
                for (int j = 0; j < ArrayItem.GetLength(1); j++)
                {
                    s += "{ ";
                    for (int k = 0; k < ArrayItem.GetLength(2); k++)
                    {
                        s += $"{ArrayItem[i, j, k]} ";
                    }
                    s += "} ";
                }
            }
            return s;
        }
    }
}
