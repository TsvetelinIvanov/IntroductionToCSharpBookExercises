using System;

namespace _12DynamicStack
{
    class Program
    {
        static void Main()
        {
            DynamicStack<int> dynamicStack = new DynamicStack<int>();
            Console.WriteLine("The dynamic stack is initialized.");
            Console.WriteLine("Count: " + dynamicStack.Count);

            Console.Write("Push elements test: ");
            for (int i = 0; i < 5; i++)
            {
                dynamicStack.Push(i + 1);
            }

            Print(dynamicStack);

            Console.WriteLine();
            Console.WriteLine("Pop elements test: ");
            Console.WriteLine(dynamicStack.Pop().Element);
            Console.WriteLine(dynamicStack.Pop().Element);            
            Console.Write("The stack after pop: ");
            Print(dynamicStack);

            Console.WriteLine("Clear test: ");
            dynamicStack.Clear();
            try
            {
                dynamicStack.Pop();
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType() + ": " + ioe.Message);
            }

            try
            {
                dynamicStack.Peek();
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType() + ": " + ioe.Message);
            }

            Print(dynamicStack);

            for (int i = 0; i < 5; i++)
            {
                dynamicStack.Push(i + 1);
            }

            Console.WriteLine("Peek test: ");
            Node<int> peekElement = dynamicStack.Peek();
            if (peekElement != null)
            {
                Console.WriteLine("The top element: " + peekElement.Element);
            }
            else
            {
                Console.WriteLine("The stack is empty!");
            }

            Console.WriteLine("Contains element:");
            Console.WriteLine("If the element exists: " + dynamicStack.Contains(5));            
            Console.WriteLine("If the element doesn`t exist: " + dynamicStack.Contains(12));           
        }

        public static void Print(DynamicStack<int> dynamicStack)
        {
            int[] array = dynamicStack.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.WriteLine(array[i]);
                    break;
                }

                Console.Write(array[i] + ", ");
            }            
        }
    }
}