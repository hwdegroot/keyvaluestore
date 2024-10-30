namespace Common.Domain;

public class LinkedQueue<T> : IQueue<T>
{
    private Item<T>? _front = null;
    private Item<T>? _back = null;
    private uint _size = 0;
    public uint Size => _size;

    /// <summary>Push a new item onto the queue.</  summary>
    /// <param name="item">The item to queue.</param>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    public void Enqueue(T item)
    {
        var newItem = new Item<T> { Value = item };

        if (_front == null)
        {
            _front = newItem;
            _back = newItem;
        }
        else
        {
            _back!.Next = newItem;
            newItem.Previous = _back;
            _back = newItem;
        }

        _size++;
    }

    /// <summary>Remove and return the next item in the queue</summary>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    /// <returns>The next item in the queue.</returns>
    public T Dequeue()
    {
        ThrowIfEmpty();

        var item = _front!.Value;
        _front = _front.Next;
        if (_front != null)
        {
            _front.Previous = null;
        }

        _size--;
        return item;
    }

    /// <summary>Get the Current item in the queue without removing it.</summary>
    /// <returns>The current item object</returns>
    public Item<T>? Current()
    {
        return _front;
    }

    public bool IsEmpty => _size == 0;

    private void ThrowIfEmpty()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
