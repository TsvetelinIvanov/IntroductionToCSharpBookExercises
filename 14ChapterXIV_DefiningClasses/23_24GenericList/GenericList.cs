using System;
using System.Text;
using System.Linq;

namespace _23_24GenericList
{
    public class GenericList<T>
    {
        private const int InitialCapacity = 4;

        private T[] array;
        private int count;              
        
        public GenericList()
        {
            this.array = new T[InitialCapacity];
            this.count = 0;
        }
        
        public GenericList(int capacity)
        {
            if (capacity < 4)
            {
                this.array = new T[InitialCapacity];
            }
            else
            {
                this.array = new T[capacity];
            }

            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.array.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                return this.array[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                this.array[index] = value;
            }
        }

        public bool Contains(T item)
        {
            return this.array.Contains(item);
        }

        public int IndexOf(T item)
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Add(T item)
        {
            this.Insert(this.Count, item);
        }
        
        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            T[] extendedArray = this.array;
            if (this.Count + 1 == this.array.Length)
            {
                extendedArray = new T[this.array.Length * 2];
            }

            Array.Copy(this.array, extendedArray, index);
            count++;
            Array.Copy(this.array, index, extendedArray, index + 1, this.Count - index - 1);
            extendedArray[index] = item;
            this.array = extendedArray;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            T item = this.array[index];
            Array.Copy(this.array, index + 1, this.array, index, this.Count - index);
            array[this.Count - 1] = default(T);
            this.count--;

            return item;
        }

        public int Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return index;
            }

            Array.Copy(this.array, index + 1, this.array, index, this.Count - index + 1);
            count--;

            return index;
        }

        public void Clear()
        {
            this.array = new T[InitialCapacity];
            this.count = 0;
        }       

        public override string ToString()
        {
            StringBuilder arrayStringBuilder = new StringBuilder("{ ");
            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count - 1)
                {
                    arrayStringBuilder.Append(this.array[i]);
                    break;
                }

                arrayStringBuilder.Append(this.array[i] + ", ");
            }

            arrayStringBuilder.AppendLine(" }");
            //Console.WriteLine(arrayStringBuilder);

            return arrayStringBuilder.ToString();
        }
    }
}