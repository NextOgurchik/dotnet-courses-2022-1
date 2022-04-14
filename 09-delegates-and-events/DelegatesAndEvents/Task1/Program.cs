using System;

namespace Task1
{
    internal class Program
    {
        static string[] BubbleSort(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    Func<string, string, bool> comparer = Compare(array[i], array[j]);
                    if (comparer.Invoke(array[i], array[j]))
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            return array;
        }
        static Func<string, string, bool> Compare(string string1, string string2)
        {
            if (string1.Length != string2.Length)
            {
                return (str1, str2) =>
                {
                    if (str1.Length > str2.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    };
                };
            }
            else
            {
                return (str1, str2) =>
                {
                    int i = 0;
                    while (i < string1.Length)
                    {
                        if (string1[i] > string2[i])
                        {
                            return true;
                        }
                        else if (string1[i] < string2[i])
                        {
                            return false;
                        }
                        i++;
                    }
                    return false;
                };
            }
        }
        static void Main(string[] args)
        {
            var str = new string[3] { "AA", "A", "B" };
            BubbleSort(str);
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }
    }
}

