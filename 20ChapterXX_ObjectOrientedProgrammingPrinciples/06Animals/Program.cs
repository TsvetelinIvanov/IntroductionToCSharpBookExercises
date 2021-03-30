using System;

namespace _06Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[] 
            { 
                new Dog("Balkan", 3, "Male"),
                new Frog("Fifi", 1, "Female"),
                new Cat("Lora", 4, "Female"),
                new Kitten("Pisi", 1),
                new Tomcat("Tufo", 5)
            };
            
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }       
    }
}