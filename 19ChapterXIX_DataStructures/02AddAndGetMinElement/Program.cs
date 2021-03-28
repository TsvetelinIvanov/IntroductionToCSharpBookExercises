using System;
using System.Linq;

namespace _02AddAndGetMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            FastAddAndGetMinElementStructure<string> stringStructure = new FastAddAndGetMinElementStructure<string>(Console.ReadLine());
            string[] strings = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strings.Length; i++)
            {
                stringStructure.Add(strings[i]);
            }

            Console.WriteLine(stringStructure.MinElement);
            Console.WriteLine(string.Join(", ", stringStructure));

            FastAddAndGetMinElementStructure<int> numberStructure = new FastAddAndGetMinElementStructure<int>(int.Parse(Console.ReadLine()));
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                numberStructure.Add(numbers[i]);
            }

            Console.WriteLine(numberStructure.MinElement);
            Console.WriteLine(string.Join(", ", numberStructure));
        }
    }
}