namespace _11DoubleLinkedList
{
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public MyLinkedListNode<T> Previous { get; internal set; }

        public MyLinkedListNode<T> Next { get; internal set; }        
    }
}
