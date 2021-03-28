using System.Collections.Generic;

namespace _01MultiDictionary
{
    public class MultiDictionary<Tkey, TValue> : Dictionary<Tkey, List<TValue>>
    {
        public void Add(Tkey key, TValue value)
        {
            if (!base.ContainsKey(key))
            {
                base.Add(key, new List<TValue>());
            }
                
            base[key].Add(value);
        }
    }
}