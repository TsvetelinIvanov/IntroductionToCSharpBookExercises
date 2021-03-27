using System;
using System.Collections.Generic;

namespace _07CuckooHashing
{
    public class CuckooHashingTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int DefaultCapacity = 16;

        private int currentCapacity;
        private int count;
        private Nullable<KeyValuePair<K, V>>[] hashTable;

        

        public CuckooHashingTable(int capacity)
        {            
            this.currentCapacity = capacity;
            this.count = 0;
            this.hashTable = new Nullable<KeyValuePair<K, V>>[capacity];
        }

        public CuckooHashingTable() : this(DefaultCapacity)
        {

        }

        public V this[K key]
        {
            get
            {
                int[] hashCodes = this.GetThreeHashCodes(key);
                foreach (int hashCode in hashCodes)
                {
                    if (this.hashTable[hashCode] != null && this.hashTable[hashCode].Value.Key.Equals(key))
                    {
                        return this.hashTable[hashCode].Value.Value;
                    }
                }

                throw new ArgumentException($"Cannot find key-value pair with this key: {key}!");
            }

            set
            {
                int[] hashCodes = this.GetThreeHashCodes(key);
                foreach (int hashCode in hashCodes)
                {
                    if (this.hashTable[hashCode] != null && this.hashTable[hashCode].Value.Key.Equals(key))
                    {
                        this.hashTable[hashCode] = new KeyValuePair<K, V>(key, value);
                        return;
                    }
                }

                throw new ArgumentException($"Cannot find key-value pair with this key: {key}!");
            }
        }

        public int Count => this.count;

        public bool ContainsKey(K key)
        {
            int[] hashCodes = this.GetThreeHashCodes(key);

            foreach (int hashCode in hashCodes)
            {
                if (this.hashTable[hashCode] != null && this.hashTable[hashCode].Value.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public ICollection<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();
                foreach (Nullable<KeyValuePair<K, V>> keyValuePair in this.hashTable)
                {
                    if (keyValuePair.HasValue)
                    {
                        keys.Add(keyValuePair.Value.Key);
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
                foreach (Nullable<KeyValuePair<K, V>> keyValuePair in this.hashTable)
                {
                    if (keyValuePair.HasValue)
                    {
                        values.Add(keyValuePair.Value.Value);
                    }
                }

                return values;
            }
        }
                
        public void Add(K key, V value)
        {
            int[] hashCodes = this.GetThreeHashCodes(key);
            this.CheckKeyForDuplicate(hashCodes, key);
            if (this.hashTable[hashCodes[0]] == null)
            {
                this.hashTable[hashCodes[0]] = new KeyValuePair<K, V>(key, value);
            }
            else if (this.hashTable[hashCodes[1]] == null)
            {
                this.hashTable[hashCodes[1]] = new KeyValuePair<K, V>(key, value);
            }
            else
            {
                if (this.hashTable[hashCodes[2]] == null)
                {
                    this.hashTable[hashCodes[2]] = new KeyValuePair<K, V>(key, value);
                }
                else
                {
                    Nullable<KeyValuePair<K, V>> movingKeyValuePair = this.hashTable[hashCodes[2]];
                    this.hashTable[hashCodes[2]] = new KeyValuePair<K, V>(key, value);
                    this.FindNewPlace(movingKeyValuePair, hashCodes[2], new HashSet<int>() { hashCodes[2] });
                }
            }

            this.count++;
        }

        public void Remove(K key)
        {
            int[] hashCodes = this.GetThreeHashCodes(key);
            foreach (int hashCode in hashCodes)
            {
                if (this.hashTable[hashCode] != null && this.hashTable[hashCode].Value.Key.Equals(key))
                {
                    this.hashTable[hashCode] = null;
                    this.count--;
                    return;
                }
            }

            throw new ArgumentException($"Cannot find key-value pair with this key: {key}!");
        }

        public void Clear()
        {            
            this.currentCapacity = DefaultCapacity;
            this.count = 0;
            this.hashTable = new Nullable<KeyValuePair<K, V>>[DefaultCapacity];
        }        

        private int[] GetThreeHashCodes(K key)
        {
            int[] hashCodes = new int[3];
            hashCodes[0] = Math.Abs(key.GetHashCode() % currentCapacity);
            hashCodes[1] = Math.Abs((key.GetHashCode() * 83 + 7) % currentCapacity);
            hashCodes[2] = Math.Abs((key.GetHashCode() * key.GetHashCode() + 19) % currentCapacity);
            return hashCodes;
        }

        private void CheckKeyForDuplicate(int[] hashCodes, K key)
        {
            foreach (int item in hashCodes)
            {
                if (this.hashTable[item].HasValue && this.hashTable[item].Value.Key.Equals(key))
                {
                    throw new ArgumentException($"An element with the same key: {key} already exists in the CuckooHashingTable<TKey, TValue>!");
                }
            }
        }

        private void FindNewPlace(KeyValuePair<K, V>? movingKeyValuePair, int oldPosition, HashSet<int> hashSetVisitedPosiotion)
        {
            int[] hashCodes = GetThreeHashCodes(movingKeyValuePair.Value.Key);
            int numberOfLastPossiblePosition = 0;
            bool needToContinueReplacing = true;
            for (int i = 0; i < hashCodes.Length; i++)
            {
                if (hashCodes[i] == oldPosition)
                {
                    continue;
                }

                if (this.hashTable[hashCodes[i]] == null)
                {
                    this.hashTable[hashCodes[i]] = movingKeyValuePair;
                    needToContinueReplacing = false;

                    break;
                }

                numberOfLastPossiblePosition = i;
            }

            if (needToContinueReplacing)
            {
                if (hashSetVisitedPosiotion.Contains(hashCodes[numberOfLastPossiblePosition]))
                {
                    this.ResizeHashTable();
                    if (this.hashTable[hashCodes[numberOfLastPossiblePosition]] == null)
                    {
                        this.hashTable[hashCodes[numberOfLastPossiblePosition]] = movingKeyValuePair;
                    }
                    else
                    {
                        this.FindNewPlace(movingKeyValuePair, hashCodes[numberOfLastPossiblePosition], new HashSet<int>() { hashCodes[numberOfLastPossiblePosition] });
                    }
                }
                else
                {
                    HashSet<int> oldHashSetVisitedPosiotion = hashSetVisitedPosiotion;
                    oldHashSetVisitedPosiotion.Add(hashCodes[numberOfLastPossiblePosition]);
                    Nullable<KeyValuePair<K, V>> newMovingPair = this.hashTable[hashCodes[numberOfLastPossiblePosition]];
                    this.hashTable[hashCodes[numberOfLastPossiblePosition]] = movingKeyValuePair;

                    this.FindNewPlace(newMovingPair, hashCodes[numberOfLastPossiblePosition], oldHashSetVisitedPosiotion);
                }
            }
        }

        private void ResizeHashTable()
        {
            this.currentCapacity *= 2;
            Nullable<KeyValuePair<K, V>>[] oldHashTable = this.hashTable;
            Nullable<KeyValuePair<K, V>>[] newHashTable = new Nullable<KeyValuePair<K, V>>[this.currentCapacity];
            this.hashTable = newHashTable;
            this.count = 0;
            foreach (Nullable<KeyValuePair<K, V>> keyValuePair in oldHashTable)
            {
                if (keyValuePair.HasValue)
                {
                    this.Add(keyValuePair.Value.Key, keyValuePair.Value.Value);
                }
            }
        }       

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (Nullable<KeyValuePair<K, V>> keyValuePair in hashTable)
            {
                if (keyValuePair != null)
                {
                    yield return keyValuePair.Value;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}