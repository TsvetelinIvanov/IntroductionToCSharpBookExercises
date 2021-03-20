using System;

namespace _23_24GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> genericListInt = new GenericList<int>();
            GenericList<string> genericListString = new GenericList<string>();
            int elementsToAddCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < elementsToAddCount; i++)
            {
                genericListInt.Add(int.Parse(Console.ReadLine()));
                genericListString.Add(Console.ReadLine());
            }

            Console.WriteLine(genericListInt.Count);
            Console.WriteLine(genericListInt.Capacity);
            Console.WriteLine(genericListString.Count);
            Console.WriteLine(genericListString.Capacity);

            genericListInt.Insert(0, 9);
            genericListString.Insert(0, "first");
            Console.WriteLine(genericListInt.Contains(9));
            Console.WriteLine(genericListInt.IndexOf(9));
            Console.WriteLine(genericListString.Contains("first"));
            Console.WriteLine(genericListString.IndexOf("first"));

            genericListInt.Remove(1);
            genericListString.Remove(1);
            genericListString.Remove("some");

            for (int i = 0; i < genericListInt.Count; i++)
            {
                Console.WriteLine(genericListInt[i]);
                Console.WriteLine(genericListString[i]);
            }

            Console.WriteLine(genericListInt);
            Console.WriteLine(genericListString);

            genericListInt.Clear();
            genericListString.Clear();

            Console.WriteLine(genericListInt);
            Console.WriteLine(genericListString);
        }
    }
}