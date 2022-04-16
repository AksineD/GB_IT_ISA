namespace HW1_PolishNotation
{
    internal class MyStack<T>
    {
        private readonly T[] _items;

        public MyStack()
            : this(100)
        {
        }
        public MyStack(int capacity)
        {
            this._items = new T[capacity];
        }
        public int Count { get; private set; }

        public T Peek()
        {
            if (this.Count - 1 == -1) throw new Exception("Stack Underflow");
            //Console.WriteLine($"current peeked {this._items[this.Count - 1]} index: {this.Count - 1}");
            return this._items[this.Count - 1];
        }

        public T Pop()
        {
            if (this.Count - 1 == -1) throw new Exception("Stack Underflow");
            //Console.WriteLine($"current poped {this._items[this.Count - 1]} index: {this.Count - 1}");
            this.Count--;
            return this._items[this.Count];
        }

        public void Push(T item)
        {
            if (this.Count >= this._items.Length) throw new Exception("Stack Overflow");
            //Console.WriteLine($"current pushed {item} index: {this.Count}");
            this._items[this.Count] = item;
            this.Count++;
        }
    }
}