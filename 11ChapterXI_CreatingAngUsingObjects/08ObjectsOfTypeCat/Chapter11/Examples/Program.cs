using System;

namespace Chapter11.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat[] cats = new Cat[10];
            string[] colors = new string[] { "white", "red", "blue", "green", "gold", "yellow", "purple", "violet", "gray", "black" };
            for (int i = 0; i < cats.Length; i++)
            {
                cats[i] = new Cat("Cat" + Sequence.NextValue(), colors[i]);
            }

            foreach (Cat cat in cats)
            {
                cat.SayMiau();
                Console.WriteLine($"{cat.Name} is {cat.Color}.");
            }
        }
    }
}