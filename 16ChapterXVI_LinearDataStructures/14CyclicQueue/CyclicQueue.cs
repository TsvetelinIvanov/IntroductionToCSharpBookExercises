using System;

namespace _14CyclicQueue
{
    public class CyclicQueue<T>
    {
        public const int InitialCapacity = 4;

		private int count;
		private int capacity;

		private int startIndex;
		private int endIndex;

		private T[] queueElements;

		public CyclicQueue(int capacity = InitialCapacity)
		{
			if (capacity <= 0)
			{
				throw new InvalidOperationException("The capacity cannot be negative!");
			}

			this.count = 0;
			this.capacity = capacity;

			this.startIndex = 0;
			this.endIndex = 0;

			this.queueElements = new T[capacity];
		}

		public int Count
		{
			get { return this.count; }
		}

		public int Capacity
		{
			get { return this.capacity; }
		}		

		public void Enqueue(T value)
		{
			if (this.IsQueueFull())
			{
				this.DoubleCapacity();
			}

			this.queueElements[this.endIndex % this.capacity] = value;
			this.endIndex++;
			this.count++;
		}

		public T Dequeue()
		{
			if (this.count <= 0)
			{
				throw new InvalidOperationException("Queue is empty!");
			}

			T value = queueElements[this.startIndex % this.capacity];
			queueElements[this.startIndex % this.capacity] = default;

			this.startIndex++;
			this.count--;

			return value;
		}

		public T Peek()
		{
			if (count <= 0)
			{
				throw new InvalidOperationException("Queue is empty!");
			}

			T value = queueElements[this.startIndex % this.capacity];

			return value;
		}		

		private bool IsQueueFull()
		{
			bool indexMatch = (this.startIndex % this.capacity) == (this.endIndex % this.capacity);
			bool hasElements = this.Count > 0;

			return indexMatch && hasElements;
		}

		private void DoubleCapacity()
		{
			int newCapacity = this.capacity * 2;

			T[] newQueueElements = new T[newCapacity];

			Array.Copy(queueElements, newQueueElements, capacity);

			capacity = newCapacity;
			queueElements = newQueueElements;
		}	
    }
}