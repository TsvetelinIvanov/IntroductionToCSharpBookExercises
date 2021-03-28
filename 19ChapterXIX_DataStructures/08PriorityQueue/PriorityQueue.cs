using Magnum.Collections;
using System;

namespace _08PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> bag;       

        public PriorityQueue()
        {
            bag = new OrderedBag<T>();
        }

        public int Count => this.bag.Count;

        public void Enqueue(T element)
        {
            bag.Add(element);
        }

        public T Dequeue()
        {
            T element = bag.GetFirst();
            bag.RemoveFirst();

            return element;
        }
    }
}