using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname, sname, patr;
            DateTime doB;
            Console.Write("Введите фамилию: ");
            sname = Console.ReadLine();
            Console.Write("Введите имя: ");
            fname = Console.ReadLine();
            Console.Write("Введите отчество: ");
            patr = Console.ReadLine();
            Console.Write("Введите дату рождения: ");
            doB = Convert.ToDateTime(Console.ReadLine());
            var user = new User(fname, sname, patr, doB);
            Console.WriteLine(user);
        }
    }
}