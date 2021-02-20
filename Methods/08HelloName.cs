using System;

namespace _08HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            GreetByName(name);
        }

        static void GreetByName(string name)
        {
            Console.WriteLine("Hello, " + name + "!");
        }
    }
}
