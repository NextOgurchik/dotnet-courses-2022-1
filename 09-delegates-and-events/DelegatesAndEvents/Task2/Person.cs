using System;

namespace Task2
{
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public void Greetings(object sender, OfficeEventArgs e)
        {
            if (e.Time.Hour < 12)
            {
                Console.WriteLine($"Доброе утро, {e.Name}! - сказал {Name}");
            }
            else if (e.Time.Hour >= 12 && e.Time.Hour <= 17)
            {
                Console.WriteLine($"Добрый день, {e.Name}! - сказал {Name}");
            }
            else
            {
                Console.WriteLine($"Добрый вечер, {e.Name}! - сказал {Name}");
            }
        }

        public void Farewell(object sender, OfficeEventArgs e)
        {
            Console.WriteLine($"До свидания, {e.Name}! - сказал {Name}");
        }
    }
}
