using System;

namespace _08ObjectToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello ";
            string world = "World!";
            object helloWorld = hello + world;
            string helloToWorld = (string)helloWorld;
            Console.WriteLine(helloToWorld);
        }
    }
}
