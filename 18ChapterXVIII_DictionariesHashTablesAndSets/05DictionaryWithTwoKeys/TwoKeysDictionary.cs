using System;
using System.Collections;
using System.Collections.Generic;

namespace _05DictionaryWithTwoKeys
{
    public class TwoKeysDictionary<K1, K2, V> : IEnumerable<Tuple<K1, K2, V>>
    {
        private Dictionary<K1, Dictionary<K2, V>> container;

        public TwoKeysDictionary()
        {
            this.container = new Dictionary<K1, Dictionary<K2, V>>();            
        }

        public V this[K1 key1, K2 key2]
        {
            get
            {
                if (!this.Contains(key1, key2))
                {
                    throw new KeyNotFoundException();
                }

                return this.container[key1][key2];
            }
        }

        public int Count
        {
            get { return this.container.Count; }
        }

        public ICollection<V> Values
        {
            get
            {
                List<V> values = new List<V>();
                foreach (KeyValuePair<K1, Dictionary<K2, V>> firstKeyValuePair in this.container)
                {
                    foreach (KeyValuePair<K2, V> secondKeyValuePair in firstKeyValuePair.Value)
                    {
                        values.Add(secondKeyValuePair.Value);
                    }
                }

                return values;
            }
        }

        public bool Contains(K1 key1, K2 key2)
        {
            return this.container.ContainsKey(key1) && container[key1].ContainsKey(key2);
        }

        public bool Add(K1 key1, K2 key2, V value)
        {
            if (this.Contains(key1, key2))
            {
                return false;
            }

            if (this.container.ContainsKey(key1))
            {
                return false;
            }

            this.container[key1] = new Dictionary<K2, V>();
            this.container[key1][key2] = value;

            return true;
        }

        public bool Remove(K1 key1, K2 key2)
        {
            if (!this.Contains(key1, key2))
            {
                return false;
            }

            this.container.Remove(key1);

            return true;
        }

        public void Clear()
        {
            this.container.Clear();
        }

        public IEnumerator<Tuple<K1, K2, V>> GetEnumerator()
        {            
            foreach (KeyValuePair<K1, Dictionary<K2, V>> firstPair in this.container)
            {
                K1 key1 = firstPair.Key;
                foreach (KeyValuePair<K2, V> secondPair in firstPair.Value)
                {
                    K2 key2 = secondPair.Key;
                    V value = secondPair.Value;

                    yield return new Tuple<K1, K2, V>(key1, key2, value);
                    break;
                }                 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}