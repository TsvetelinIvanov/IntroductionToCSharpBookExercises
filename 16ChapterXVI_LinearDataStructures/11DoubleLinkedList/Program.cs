using System;

namespace _11DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            Console.WriteLine("Linked list initialized.");
            Console.WriteLine("Count: " + linkedList.Count);

            Console.WriteLine("Add first test");
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddFirst(i);
            }

            Print(linkedList);
            linkedList.Clear();

            Console.WriteLine("Add last test");
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }
            Print(linkedList);
            Console.WriteLine();

            Console.WriteLine("**********************");
            Console.WriteLine("Remove tests");
            Console.WriteLine(" -remove existing element");
            linkedList.Remove(4);
            Print(linkedList);

            Console.WriteLine(" -remove nonexisting element");
            linkedList.Remove(1112);
            Print(linkedList);

            Console.WriteLine(" -remove first element");
            linkedList.Remove(0);
            Print(linkedList);

            Console.WriteLine(" -remove last element");
            linkedList.Remove(9);
            Print(linkedList);

            Console.WriteLine(" -remove element in an empty list");
            linkedList.Clear();
            linkedList.Remove(2);
            Print(linkedList);

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }

            Console.WriteLine("**********************");
            Console.WriteLine("Find tests");            
            Console.WriteLine(" -find existing element");
            MyLinkedListNode<int> found = linkedList.Find(2);
            if (found != null)
            {
                Console.WriteLine(" Found: " + found.Value);
            }

            Console.WriteLine(" -find nonexisting element");
            found = linkedList.Find(90);
            if (found != null)
            {
                Console.WriteLine(" Found: " + found.Value);
            }

            Console.WriteLine(" -find first/last element");
            found = linkedList.Find(0);
            if (found != null)
            {
                Console.WriteLine(" Found: " + found.Value);
            }

            found = linkedList.Find(9);
            if (found != null)
            {
                Console.WriteLine(" Found: " + found.Value);
            }

            Console.WriteLine();
            Console.WriteLine("**********************");
            Console.WriteLine("Insert tests");
            Console.WriteLine(" -insert in middle");
            linkedList.InsertAt(50, 3);
            Print(linkedList);
            linkedList.Remove(50);

            Console.WriteLine(" -insert at begining/ending");
            linkedList.InsertAt(-50, 0);
            linkedList.InsertAt(50, 11);
            Print(linkedList);

            Console.WriteLine(" -insert out of range");
            try
            {
                linkedList.InsertAt(10000, 2054);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Thrown exception: " + e.GetType());
            }

            Console.WriteLine();
            Console.WriteLine("**********************");
            Console.WriteLine("ElementAt tests");
            Console.WriteLine(" -element at middle index");
            MyLinkedListNode<int> nodeAt = linkedList.ElementAt(4);
            Console.WriteLine("Element [4]: " + nodeAt.Value);
            Console.WriteLine(" -element at first/last index");
            nodeAt = linkedList.ElementAt(0);
            Console.WriteLine("Element [0]: " + nodeAt.Value);
            nodeAt = linkedList.ElementAt(linkedList.Count - 1);
            Console.WriteLine("Element [{0}]: {1}", linkedList.Count - 1, nodeAt.Value);
            Console.WriteLine(" -element in out of range index");
            try
            {
                nodeAt = linkedList.ElementAt(5000);
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine("Thrown exception: " + ioore.GetType());
            }

            Console.WriteLine();
        }
        static void Print(MyLinkedList<int> list)
        {
            int[] array = list.ToArray();
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}