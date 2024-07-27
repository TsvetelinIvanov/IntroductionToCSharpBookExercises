using System.Collections;
using System.Collections.Generic;

namespace _06MultiDictionary
{
    public class MultiDictionary<K, V> : IEnumerable<KeyValuePair<K, List<V>>>
	{
		private Dictionary<K, List<V>> container;

		public MultiDictionary()
		{
			this.container = new Dictionary<K, List<V>>();
		}

		public List<V> this[K key]
		{
			get { return this.container[key]; }
			set { this.container[key] = value; } 			
		}

		public int Count => this.container.Count;

		public ICollection<K> Keys
		{
			get
			{
				List<K> keys = new List<K>();
				foreach (K key in this.container.Keys)
				{
					keys.Add(key);
				}

				return keys;
			}
		}

		public ICollection<V> Values
		{
			get
			{
				List<V> values = new List<V>();
				foreach (List<V> value in this.container.Values)
				{
					values.AddRange(value);
				}

				return values;
			}
		}

		public bool ContainsKey(K key)
		{
			bool containsKey = this.container.ContainsKey(key);

			return containsKey;
		}

		public bool ContainsValue(V value)
		{
			bool containsValue = false;
            		foreach (List<V> values in this.container.Values)
            		{
                		if (values.Contains(value))
                		{
					containsValue = true;
					break;
                		}
            		}

			return containsValue;
		}

		public void Add(K key, V value)
		{			
			if (!this.ContainsKey(key))
			{
				this.container.Add(key, new List<V>());
			}

			this.container[key].Add(value);
		}

		public bool Remove(K key)
		{
			return this.container.Remove(key);
		}

		public bool RemoveValue(K key, V value)
		{
			if (!this.ContainsKey(key))
            		{
				return false;
            		}

			return this.container[key].Remove(value);
		}

		public void Clear()
		{
			this.container.Clear();
		}

		public List<V> GetValues(K key)
		{
			if (!this.container.ContainsKey(key))
            		{
				return new List<V>();
            		}

			return this.container[key];
		}

        	public IEnumerator<KeyValuePair<K, List<V>>> GetEnumerator()
        	{
            		foreach (KeyValuePair<K, List<V>> keyValuePair in this.container)
            		{
				yield return keyValuePair;
            		}
        	}

        	IEnumerator IEnumerable.GetEnumerator()
        	{
			return this.GetEnumerator();
		}
    }
}
