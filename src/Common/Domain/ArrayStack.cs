namespace Common.Domain;

// Implements the last-in-first-out (LIFO) stack data-structure.
// Items are added and removed from the top of the stack only.
public class ArrayStack<T>(uint capacity = ArrayStack<T>.InitialCapacity) : IStack<T>
{
    private const uint InitialCapacity = 10;
    private const uint ResizeFactor = 2;
    public uint Capacity { get; private set; } = InitialCapacity;
    private T[] _items = new T[capacity];
    private uint _size = 0;
    public uint Size => _size;

    /// <summary>Add an item to the top of the stack.</summary>
    /// <param name="item">The item to add to the stack.</param>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    public void Push(T item)
    {
        if (_size == _items.Length)
        {
            Capacity *= ResizeFactor;
            var newItems = new T[Capacity];
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

        _size--;

        return item;
    }
}

