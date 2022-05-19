using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    public class EndSortEventArgs:EventArgs
    {
        public string[] Array { get; set; }
        public EndSortEventArgs(string[] array)
        {
            Array = array;
        }
    }
    internal class Program
    {
        public static event EventHandler<EndSortEventArgs> EndSort;
        static Thread SortAsync(string[] array, Func<string, string, int> Comparer)
        {
            Thread thread = new Thread(() => {
            Sort(array, Comparer);
            EndSort?.Invoke(null, new EndSortEventArgs(array));
            });
            thread.Start();
            return thread;
        }

        private static void ThreadEndSort(object sender, EndSortEventArgs e)
        {
            Console.WriteLine("Массив отсортирован");
            foreach (var item in e.Array)
            {
                Console.WriteLine(item);
            }
        }

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
            var str = new string[7] { "AB", "A", "B", "BA", "B", "CA", "A" };
            EndSort += ThreadEndSort;
            var thread = SortAsync(str, CompareStrings);
        }
    }
}
