using System;

namespace _07StringToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello ";
            string world = "World!";
            object helloWorld = hello + world;
            Console.WriteLine(helloWorld);
        }
    }
}
