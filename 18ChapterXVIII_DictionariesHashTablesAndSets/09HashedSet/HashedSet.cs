using System.Collections.Generic;

namespace _09HashedSet
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<T, T>();
        }

        public int Count => this.hashTable.Count;

        public bool Find(T item)
        {
            return this.hashTable.ContainsKey(item);
        }

        public void Add(T item)
        {
            this.hashTable.Add(item, item);
        }        

        public void Remove(T item)
        {
            this.hashTable.Remove(item);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void Union(HashedSet<T> hashedSet)
        {
            foreach (T item in hashedSet)
            {
                if (!this.Find(item))
                {
                    this.Add(item);
                }
            }
        }

        public void Intersect(HashedSet<T> hashedSet)
        {
            HashTable<T, T> newtable = new HashTable<T, T>();
            foreach (T item in hashedSet)
            {
                if (this.Find(item))
                {
                    newtable.Add(item, item);
                }
            }

            this.hashTable = newtable;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return this.hashTable.Keys.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return hashTable.Keys.GetEnumerator();
        }
    }
}