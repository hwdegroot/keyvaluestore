using System.Text;

namespace Common.Domain;

// Implements the last-in-first-out (LIFO) stack data-structure.
// Items are added and removed from the top of the stack only.
public class LinkedStack<T> : IStack<T>
{
    private Item<T>? _front = null;
    private Item<T>? _back = null;
    private uint _size = 0;
    public uint Size => _size;

    /// <summary>Add an item to the top of the stack.</summary>
    /// <param name="item">The item to add to the stack.</param>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    /// <returns>The item</returns>
    public void Push(T item)
    {
        if (_front == null)
        {
            _front = new Item<T> { Value = item };
            _back = _front;
        }
        else
        {
            var newItem = new Item<T> { Value = item, Next = _front };
            _front.Previous = newItem;
            _front = newItem;
        }
        _size++;
    }

    /// <summary>Inspect the item at the top of the stack.</summary>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    /// <returns>The item at the top of the stack.</returns>
    public T Peek()
    {
        ThrowIfEmpty();

        return _front!.Value;
    }

    /// <summary>Remove and return the item at the top of the stack.</summary>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception
    /// <returns>The item at the top of the stack.</returns>
    public T Pop()
    {
        ThrowIfEmpty();

        T item = _front!.Value;
        _front = _front.Next;

        if (_front != null)
            _front.Previous = null;

        _size--;

        return item;
    }

    /// <summary>Get the Current item in the stack without removing it.</summary>
    /// <returns>The current item object</returns>
    public Item<T>? Current()
    {
        return _front;
    }

    public bool IsEmpty => _size == 0;

    private void throwIfEmpty()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }
    }
}
