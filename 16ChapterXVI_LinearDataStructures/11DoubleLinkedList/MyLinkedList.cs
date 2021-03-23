using System;

namespace _11DoubleLinkedList
{
    public class MyLinkedList<T> where T : IComparable
    {
        public MyLinkedList()
        {
            First = null;
            Last = null;
            this.Count = 0;
        }

        public static MyLinkedListNode<T> First { get; private set; }

        public static MyLinkedListNode<T> Last { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            if (First == null)
            {
                First = Last = new MyLinkedListNode<T>(value);
            }
            else
            {
                First.Previous = new MyLinkedListNode<T>(value);
                First.Previous.Next = First;
                First = First.Previous;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            if (Last == null)
            {
                First = Last = new MyLinkedListNode<T>(value);
            }
            else
            {
                Last.Next = new MyLinkedListNode<T>(value);
                Last.Next.Previous = Last;
                Last = Last.Next;
            }

            Count++;
        }        

        public void Remove(T value)
        {
            MyLinkedListNode<T> current = First;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        First = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Last = current.Previous;
                    }

                    this.Count--;
                    break;
                }

                current = current.Next;
            }
        }

        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T> current = First;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void InsertAt(T insertValue, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == Count)
            {
                this.AddLast(insertValue);
            }
            else
            {
                int position = 0;
                MyLinkedListNode<T> insertNode = new MyLinkedListNode<T>(insertValue);
                MyLinkedListNode<T> current = First;

                while (current != null)
                {
                    if (position == index)
                    {
                        insertNode.Previous = current.Previous;
                        insertNode.Next = current;
                        if (current.Previous != null)
                        {
                            current.Previous.Next = insertNode;
                        }
                        else
                        {
                            First = insertNode;
                        }

                        current.Previous = insertNode;
                        Count++;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                        position++;
                    }
                }
            }
        }

        public MyLinkedListNode<T> ElementAt(int index)
        {
            MyLinkedListNode<T> current = First;
            int position = 0;

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                while (current != null)
                {
                    if (position == index)
                    {
                        return current;
                    }

                    current = current.Next;
                    position++;
                }
            }

            return null;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            MyLinkedListNode<T> current = First;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            this.Count = 0;
        }
    }
}
