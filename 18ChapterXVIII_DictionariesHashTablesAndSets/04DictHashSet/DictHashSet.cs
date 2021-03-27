using System;
using System.Collections;
using System.Collections.Generic;

namespace _04DictHashSet
{
    public class DictHashSet<T> : IEnumerable<T>
    {
        private Dictionary<T, T> container;

        public DictHashSet()
        {
            this.container = new Dictionary<T, T>();
        }

        public int Count
        {
            get { return container.Count; }
        }

        public bool Contains(T element)
        {
            return this.container.ContainsKey(element);
        }

        public bool Add(T element)
        {            
            if (this.Contains(element))
            {
                return false;
            }

            this.container.Add(element, element);

            return true;
        }

        public bool Remove(T element)
        {
            bool isElementRemoved = container.Remove(element);

            return isElementRemoved;
        }

        public void Clear()
        {
            this.container.Clear();
        }

        public void Union(DictHashSet<T> otherDictHashSet)
        {
            if (otherDictHashSet == null)
            {
                throw new ArgumentNullException();
            }

            foreach (T item in otherDictHashSet)
            {
                this.Add(item);
            }
        }

        public void Intersect(DictHashSet<T> otherDictHashSet)
        {
            if (otherDictHashSet == null)
            {
                throw new ArgumentNullException();
            }

            DictHashSet<T> intersection = new DictHashSet<T>();
            foreach (T item in otherDictHashSet)
            {
                if (this.Contains(item))
                {
                    intersection.Add(item);
                }
            }

            this.container = intersection.container;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<T, T> item in this.container)
            {
                yield return item.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}