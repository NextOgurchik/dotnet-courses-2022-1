using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] myChar1, myChar2;
            var myString = new MyString("Тестовая проверка на null пройдена успешно!".ToCharArray());
            if (myString != null)
            {
                Console.WriteLine($"{myString}");
            }
            Console.Write("Введите первый массив символов: ");
            myChar1 = Console.ReadLine().ToCharArray();
            Console.Write("Введите второй массив символов: ");
            myChar2 = Console.ReadLine().ToCharArray();
            var charString1 = new MyString(myChar1);
            var charString2 = new MyString(myChar2);
            var charString3 = charString1 + charString2;
            var charString4 = charString1 - charString2;
            Console.WriteLine($"Сложение массивов: {charString3}");
            Console.WriteLine($"Вычитание массивов: {charString4}");
            string c = charString1 == charString2 ? "Элементы массивов одинаковые" : "Элементы массивов неодинаковые";
            Console.WriteLine(c);
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
