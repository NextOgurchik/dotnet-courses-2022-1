using System;
using System.IO;


namespace Task1
{
    internal class Program
    {
        public static void ProcessFile(string path)
        {
            string[] text = File.ReadAllLines(path);
            using StreamWriter writer = new StreamWriter(path);
            foreach (string line in text)
            {
                if (int.TryParse(line, out int n))
                {
                    writer.WriteLine(n * n);
                }
                else
                {
                    throw new Exception();
                }
            }
            Console.WriteLine("Успешно завершено!");
        }
        static void Main(string[] args)
        {
            ProcessFile("disposable_task_file.txt");
        }
    }
}
