﻿using System;

namespace Task1
{
    internal class Program
    {
        static void Sort(string[] array, Func<string, string, int> Comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Comparer.Invoke(array[i], array[j]) == 1)
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }
        static int CompareStrings(string string1, string string2)
        {
            if (string1.Length != string2.Length)
            {
                if (string1.Length > string2.Length)
                {
                    return 1;
                }
                else if (string1.Length < string2.Length)
                {
                    return -1;
                }
                else return 0;
            }
            else
            {
                    int i = 0;
                    while (i < string1.Length)
                    {
                        if (string1[i] > string2[i])
                        {
                            return 1;
                        }
                        else if (string1[i] < string2[i])
                        {
                            return -1;
                        }
                        i++;
                    }
                return 0;
            }
        }
        static void Main(string[] args)
        {
            var str = new string[6] { "AA", "B", "AB", "A", "B", "BA" };
            Sort(str, CompareStrings);
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }
    }
}

