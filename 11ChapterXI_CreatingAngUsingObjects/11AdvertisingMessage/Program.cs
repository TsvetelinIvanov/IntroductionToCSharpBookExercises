using System;

namespace _11AdvertisingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Продуктът е отличен.", "Това е страхотен продукт.", "Постоянно ползвам този продукт.", "Това е най-добрият продукт от тази категория." };
            string[] events = new string[] { "Вече се чувствам добре.", "Успях да се променя.", "Той направи чудо.", "Не мога да повярвам, но вече се чувствам страхотно.", "Опитайте и вие. Аз съм много доволна." };
            string[] names = new string[] { "Диана", "Петя", "Стела", "Елена", "Катя" };
            string[] families = new string[] { "Иванова", "Петрова", "Кирова" };
            string[] cities = new string[] { "София", "Пловдив", "Варна", "Русе", "Бургас" };

            Random random = new Random();
            int phrasesIndex = random.Next(0, phrases.Length);
            int eventsIndex = random.Next(0, events.Length);
            int namesIndex = random.Next(0, names.Length);
            int familiesIndex = random.Next(0, families.Length);
            int citiesIndex = random.Next(0, cities.Length);

            Console.WriteLine($"{phrases[phrasesIndex]} {events[eventsIndex]} --{names[namesIndex]} {families[familiesIndex]}, {cities[citiesIndex]}");
        }
    }
}