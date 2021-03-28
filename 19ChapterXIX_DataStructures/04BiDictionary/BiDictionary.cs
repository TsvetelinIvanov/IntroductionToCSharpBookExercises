using System;
using System.Collections;
using System.Collections.Generic;

namespace _04BiDictionary
{
    public class BiDictionary<K1, K2, T> : IEnumerable<Tuple<K1, K2, List<T>>>
    {
        private Dictionary<K1, List<T>> keys1;
        private Dictionary<K2, List<T>> keys2;
        private int count;
        
        public BiDictionary()
        {
            this.keys1 = new Dictionary<K1, List<T>>();
            this.keys2 = new Dictionary<K2, List<T>>();
            this.count = 0;
        }

        public int ElementsCount => this.count;

        public int ReferencesCount
        {
            get
            {
                int referencesCount = 0;
                foreach (KeyValuePair<K1, List<T>> keyValuePair1 in this.keys1)
                {
                    foreach (KeyValuePair<K2, List<T>> keyValuePair2 in this.keys2)
                    {                        
                        foreach (T value in keyValuePair1.Value)
                        {
                            if (keyValuePair2.Value.Contains(value))
                            {
                                referencesCount++;
                            }
                        }                        
                    }
                }

                return referencesCount;
            }
        }

        public bool ContainsFirstKey(K1 key1)
        {
            return this.keys1.ContainsKey(key1);
        }

        public bool ContainsSecondKey(K2 key2)
        {
            return this.keys2.ContainsKey(key2);
        }

        public bool ContainsKeys(K1 key1, K2 key2)
        {
            return this.keys1.ContainsKey(key1) && this.keys2.ContainsKey(key2);
        }

        public bool ContainsValue(T value)
        {
            foreach (List<T> values in this.keys1.Values)
            {
                if (values.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(K1 key1, K2 key2, T value)
        {            
            if (!this.keys1.ContainsKey(key1))
            {
                this.keys1.Add(key1, new List<T>());               
            }

            if (!this.keys2.ContainsKey(key2))
            {
                this.keys2.Add(key2, new List<T>());                
            }            

            this.keys1[key1].Add(value);
            this.keys2[key2].Add(value);
            this.count++;
        }        

        public bool RemoveValue(K1 key1, K2 key2, T value)
        {
            if (this.keys1.ContainsKey(key1) && this.keys2.ContainsKey(key2))
            {
                if (this.keys1[key1].Contains(value) && this.keys2[key2].Contains(value))
                {
                    this.keys1[key1].Remove(value);
                    this.keys2[key2].Remove(value);
                    this.count--;

                    if (this.keys1[key1].Count == 0)
                    {
                        this.keys1.Remove(key1);
                    }

                    if (this.keys2[key2].Count == 0)
                    {
                        this.keys2.Remove(key2);
                    }

                    return true;
                }                
            }

            return false;
        }

        public bool SearchByFirstKey(K1 key1, out List<T> values)
        {
            values = new List<T>();
            if (this.keys1.ContainsKey(key1))
            {
                values = new List<T>(this.keys1[key1]);

                return true;
            }

            return false;
        }

        public bool SearchBySecondKey(K2 key2, out List<T> values)
        {
            values = new List<T>();            
            if (this.keys2.ContainsKey(key2))
            {
                values = new List<T>(this.keys2[key2]);

                return true;
            }

            return false;
        }

        public bool SearchByBothKeys(K1 key1, K2 key2, out List<T> values)
        {
            values = new List<T>();
            if (this.keys1.ContainsKey(key1) && this.keys2.ContainsKey(key2))
            {
                foreach (T value in this.keys1[key1])
                {
                    if (this.keys2[key2].Contains(value))
                    {
                        values.Add(value);
                    }                    
                }

                return true;
            }

            return false;
        }

        public IEnumerator<Tuple<K1, K2, List<T>>> GetEnumerator()
        {
            foreach (KeyValuePair<K1, List<T>> keyValuePair1 in this.keys1)
            {
                foreach (KeyValuePair<K2, List<T>> keyValuePair2 in this.keys2)
                {
                    List<T> values = new List<T>();
                    foreach (T value in keyValuePair1.Value)
                    {
                        if (keyValuePair2.Value.Contains(value))
                        {
                            values.Add(value);
                        }
                    }

                    if (values.Count > 0)
                    {
                        yield return new Tuple<K1, K2, List<T>>(keyValuePair1.Key, keyValuePair2.Key, values);
                    }                    
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}