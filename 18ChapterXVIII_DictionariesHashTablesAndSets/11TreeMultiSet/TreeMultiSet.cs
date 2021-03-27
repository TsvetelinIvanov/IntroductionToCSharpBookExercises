using System;
using System.Collections.Generic;
using System.Linq;

namespace _11TreeMultiSet
{
    public class TreeMultiSet<T> : IEnumerable<T>
    {
        private int count;
        private SortedDictionary<T, int> sortedDictionary;        

        public TreeMultiSet()
        {
            this.count = 0;
            this.sortedDictionary = new SortedDictionary<T, int>();            
        }

        public TreeMultiSet(IComparer<T> comparer)
        {
            this.sortedDictionary = new SortedDictionary<T, int>(comparer);
            this.count = 0;
        }

        public int Count => this.count;
        
        public void Add(T element)
        {
            if (!this.sortedDictionary.ContainsKey(element))
            {
                this.sortedDictionary.Add(element, 0);                
            }

            this.sortedDictionary[element]++;
            this.count++;
        }

        public int Find(T element)
        {
            if (!this.sortedDictionary.ContainsKey(element))
            {
                return 0;
            }

            return this.sortedDictionary[element];
        }

        public T FindMin()
        {
            return this.sortedDictionary.FirstOrDefault().Key;
        }

        public T FindMax()
        {
            return this.sortedDictionary.LastOrDefault().Key;
        }

        public void Delete(T element)
        {
            if (!this.sortedDictionary.ContainsKey(element))
            {
                throw new ArgumentException($"There is no element {element} in our TreeMultiSet!");
            }
            
            if (this.sortedDictionary[element] > 1)
            {
                this.sortedDictionary[element]--;
            }
            else
            {
                this.sortedDictionary.Remove(element);
            }

            this.count--;
        }

        public void DeleteAll(T element)
        {
            if (!sortedDictionary.ContainsKey(element))
            {
                throw new ArgumentException($"There is no element {element} in our TreeMultiSet!");
            }
            
            this.count -= sortedDictionary[element];
            this.sortedDictionary.Remove(element);
        }        

        public void DeleteFirst()
        {
            KeyValuePair<T, int> minElements = this.sortedDictionary.First();
            if (minElements.Value > 1)
            {
                this.sortedDictionary[minElements.Key]--;
            }
            else
            {
                this.sortedDictionary.Remove(minElements.Key);
            }

            this.count--;
        }

        public void DeleteLast()
        {
            KeyValuePair<T, int> maxElements = this.sortedDictionary.Last();
            if (maxElements.Value > 1)
            {
                this.sortedDictionary[maxElements.Key]--;
            }
            else
            {
                this.sortedDictionary.Remove(maxElements.Key);
            }

            this.count--;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<T, int> pair in this.sortedDictionary)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    yield return pair.Key;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}