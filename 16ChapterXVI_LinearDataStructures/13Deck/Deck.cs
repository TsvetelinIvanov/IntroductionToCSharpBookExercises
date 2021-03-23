using System;
using System.Collections.Generic;

namespace _13Deck
{
    public class Deck<T>
    {
        private LinkedList<T> startDeck;
        private LinkedList<T> endDeck;

        public Deck()
        {
            this.startDeck = new LinkedList<T>();
            this.endDeck = new LinkedList<T>();
        }

        public void AddToStart(T element)
        {
            this.startDeck.AddFirst(element);
        }

        public void AddToEnd(T element)
        {
            this.endDeck.AddLast(element);
        }

        public T RemoveFromStart()
        {
            if (this.startDeck.Count == 0)
            {
                throw new InvalidOperationException("The start deck is empty!");
            }

            T value = this.startDeck.First.Value;
            this.startDeck.RemoveFirst();

            return value;
        }

        public T RemoveFromEnd()
        {
            if (this.endDeck.Count == 0)
            {
                throw new InvalidOperationException("The end deck is empty!");
            }

            T value = this.endDeck.Last.Value;
            this.endDeck.RemoveLast();

            return value;
        }

        public void Clear()
        {
            this.startDeck.Clear();
            this.endDeck.Clear();
        }

        public T[] ToArray()
        {
            T[] array = new T[this.startDeck.Count + this.endDeck.Count];
            int counter = 0;
            foreach (T item in this.startDeck)
            {
                array[counter] = item;
                counter++;
            }

            foreach (T item in this.endDeck)
            {
                array[counter] = item;
                counter++;
            }

            return array;
        }
    }
}