using System.Collections.Generic;
using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<string>();
            linkedList.AddFirst("5");
            linkedList.AddFirst("4");
            linkedList.AddFirst("3");
            linkedList.AddFirst("2");
            linkedList.AddFirst("1");

            var list = new List<string>
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6"
            };

            RemoveEachSecondItem(linkedList);
            RemoveEachSecondItem(list);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void RemoveEachSecondItem<T>(ICollection<T> collection)
        {
            bool isSecond = false;
            while (collection.Count > 1)
            {
                foreach (var item in collection.ToArray())
                {
                    if (isSecond)
                    {
                        collection.Remove(item);
                    }
                    isSecond = !isSecond;
                }
            }
        }
    }
}
