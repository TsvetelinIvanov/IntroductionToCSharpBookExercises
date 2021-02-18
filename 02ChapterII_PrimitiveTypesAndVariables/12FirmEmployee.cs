using System;

namespace _12FirmEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string familyName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            var employee = (firstName + " " + familyName + ", " + sex + ", " + age + " years old, " + "and his/her number is: " + number + ".");
            Console.WriteLine(employee);
        }
    }
}
