using System;
using System.Collections.Generic;

namespace _08HashTable
{
    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int DefaultCapacity = 16;

        private int currentCapacity;
        private int count;
        private int currentLoad;
        private LinkedList<KeyValuePair<K, V>>[] hashTable;

        public HashTable(int capacity)
        {
            this.count = 0;
            this.currentCapacity = capacity;
            this.hashTable = new LinkedList<KeyValuePair<K, V>>[capacity];
        }

        public HashTable() : this(DefaultCapacity)
        {

        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public int Count => this.count;      

        public ICollection<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();
                foreach (LinkedList<KeyValuePair<K, V>> item in this.hashTable)
                {
                    if (item != null)
                    {
                        foreach (KeyValuePair<K, V> element in item)
                        {
                            keys.Add(element.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                List<V> values = new List<V>();
                foreach (LinkedList<KeyValuePair<K, V>> item in this.hashTable)
                {
                    if (item != null)
                    {
                        foreach (KeyValuePair<K, V> element in item)
                        {
                            values.Add(element.Value);
                        }
                    }
                }

                return values;
            }
        }

        public bool ContainsKey(K key)
        {
            if (this.hashTable[this.GetHash(key)] != null)
            {
                foreach (KeyValuePair<K, V> item in this.hashTable[this.GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public V Find(K key)
        {
            if (hashTable[this.GetHash(key)] != null)
            {
                foreach (KeyValuePair<K, V> item in this.hashTable[this.GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new ArgumentException($"Key {key} not exist!");
        }

        public void Add(K key, V value)
        {
            if (this.currentLoad > this.hashTable.Length * 0.75)
            {
                this.Resize();
            }

            int hashCode = this.GetHash(key);
            if (this.hashTable[hashCode] == null)
            {
                LinkedList<KeyValuePair<K, V>> newList = new LinkedList<KeyValuePair<K, V>>();
                newList.AddFirst(new KeyValuePair<K, V>(key, value));
                this.hashTable[hashCode] = newList;
                this.count++;
                this.currentLoad++;
            }
            else
            {
                foreach (KeyValuePair<K, V> item in this.hashTable[hashCode])
                {
                    if (item.Key.Equals(key))
                    {
                        throw new ArgumentException($"Key {key} is already in a Hash Table!");
                    }
                }

                this.hashTable[hashCode].AddLast(new KeyValuePair<K, V>(key, value));
                this.count++;
            }
        }        

        public void Remove(K key)
        {
            int hashCode = this.GetHash(key);
            if (this.hashTable[hashCode] == null)
            {
                return;
            }

            KeyValuePair<K, V> removePair = new KeyValuePair<K, V>();
            foreach (KeyValuePair<K, V> item in this.hashTable[hashCode])
            {
                if (item.Key.Equals(key))
                {
                    removePair = item;
                }
            }

            this.hashTable[hashCode].Remove(removePair);
            this.count--;
        }

        public void Clear()
        {            
            this.count = 0;
            this.currentLoad = 0;
            this.hashTable = new LinkedList<KeyValuePair<K, V>>[DefaultCapacity];
        }

        private int GetHash(K key)
        {
            int hash = key.GetHashCode();
            if (hash < 0)
            {
                hash = -hash;
            }

            return hash % this.hashTable.Length;
        }

        private void Resize()
        {
            this.currentCapacity *= 2;
            LinkedList<KeyValuePair<K, V>>[] oldHashTable = this.hashTable;
            LinkedList<KeyValuePair<K, V>>[] newHashTable = new LinkedList<KeyValuePair<K, V>>[this.currentCapacity];
            this.hashTable = newHashTable;
            this.count = 0;
            this.currentLoad = 0;
            foreach (LinkedList<KeyValuePair<K, V>> item in oldHashTable)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, V> element in item)
                    {
                        this.Add(element.Key, element.Value);
                    }
                }
            }
        }        

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<K, V>> chain in hashTable)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> keyValuePair in chain)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}