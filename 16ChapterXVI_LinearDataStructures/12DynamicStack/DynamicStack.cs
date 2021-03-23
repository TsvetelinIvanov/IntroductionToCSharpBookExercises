using System;

namespace _12DynamicStack
{
    public class DynamicStack<T> where T : IComparable
    {
        public DynamicStack()
        {
            First = null;
            this.Count = 0;
        }

        public static Node<T> First { get; private set; }

        public int Count { get; private set; }        

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (First == null)
            {
                First = newNode;
            }
            else
            {
                Node<T> temp = First;
                First = newNode;
                First.Next = temp;
            }

            this.Count++;
        }

        public Node<T> Pop()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");                
            }

            Node<T> elementToPop = First;
            First = First.Next;
            this.Count--;

            return elementToPop;
        }               

        public Node<T> Peek()
        {
            if (First != null)
            {
                return First;
            }
            else
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }

        public bool Contains(T element)
        {
            Node<T> current = First;
            while (current != null)
            {
                if (current.Element.CompareTo(element) == 0)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            First = null;
            this.Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            Node<T> current = First;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = current.Element;
                current = current.Next;
            }

            return array;
        }
    }
}