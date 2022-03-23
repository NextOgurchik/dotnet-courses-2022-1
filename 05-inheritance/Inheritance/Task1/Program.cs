using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fname, sname, patr, pos;
            DateTime doB,doH;
            Console.Write("Введите фамилию: ");
            sname = Console.ReadLine();
            Console.Write("Введите имя: ");
            fname = Console.ReadLine();
            Console.Write("Введите отчество: ");
            patr = Console.ReadLine();
            Console.Write("Введите дату рождения: ");
            doB = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите дату найма: ");
            doH = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите должность: ");
            pos = Console.ReadLine();
            var worker = new Employee(fname, sname, patr, doB, doH, pos);
            Console.WriteLine(worker);
        }
    }
}
