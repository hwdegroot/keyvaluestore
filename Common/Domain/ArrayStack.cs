namespace Common.Domain;

// Implements the last-in-first-out (LIFO) stack data-structure.
// Items are added and removed from the top of the stack only.
public class ArrayStack<T> : IStack<T>
{
    //private int? _frontCursor = null;
    //private int? _backCursof = null;
    private int _initailCapacity;
    private T[] _items;
    private uint _size = 0;
    public uint Size => _size;

    public ArrayStack(int initialCapacity = 10)
    {
        _initailCapacity = initialCapacity;
        _items = new T[_initailCapacity];
    }

    /// <summary>Add an item to the top of the stack.</summary>
    /// <param name="item">The item to add to the stack.</param>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    public void Push(T item)
    {
        if (_size == _items.Length)
        {
            var newItems = new T[_items.Length + _initailCapacity]; // * 2
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;

        }
        _items[_size] = item;
        _size++;
    }

    /// <summary>Inspect the item at the top of the stack.</summary>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    /// <returns>The item at the top of the stack.</returns>
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _items[_size - 1];
    }

    /// <summary>Remove and return the item at the top of the stack.</summary>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    /// <returns>The item at the top of the stack.</returns>
    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }


        T item = _items[_size - 1];
        //_items[_size - 1] = default(T);

        _size--;

        return item;
    }
}

