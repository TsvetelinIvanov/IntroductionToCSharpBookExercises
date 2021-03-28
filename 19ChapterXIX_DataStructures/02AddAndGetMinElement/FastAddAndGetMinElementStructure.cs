using System;
using System.Collections;
using System.Collections.Generic;

namespace _02AddAndGetMinElement
{
    public class FastAddAndGetMinElementStructure<T> : IEnumerable<T> where T : IComparable
    {
        private List<T> elements;
        private T minElement;

        public FastAddAndGetMinElementStructure(T value)
        {
            this.elements = new List<T>() { value };
            this.minElement = value;
        }

        public T MinElement => this.minElement;
        
        public void Add(T element)
        {
            this.elements.Add(element);
            if (minElement.CompareTo(element) > 0)
            {
                this.minElement = element;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}