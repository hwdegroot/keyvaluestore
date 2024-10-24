namespace Common.Domain.ArrayQueue;

public class LinearQueue<T>(uint capacity = LinearQueue<T>.InitialCapacity) : IQueue<T>
{
    private const uint InitialCapacity = 10;
    private const uint ResizeFactor = 2;
    public uint Capacity { get; private set; } = capacity;
    private T[] _items = new T[capacity];
    // index of the first item in the queue
    private uint _front = 0;
    // index of the last item in the queue
    private uint _back = 0;
    public uint Size => _back - _front;

    ///
    /// <summary>Push a new item onto the queue.</  summary>
    /// <param name="item">The item to queue.</param>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    public void Enqueue(T item)
    {
        if (_back == Capacity)
        {
            // When we reached the end of the array, resize it
            // However, we are moving the cursor at the front, so
            // we only want to copy the items that are still in the
            // queue.
            // After resizing, the new front is the start of the array again,
            // and the new back, it the intitial back, minus the old
            // front position, because we resized.
            // for the new length we could also opt to check if the current length
            // of the queue is less than half of the current array size, so we do not have to copy
            // but just move the items
            // if the current occupied size is more than half of the available size, resize
            // else use the existing array
            var newItems = Grow();
            // When resizing, only copy the items in the queue
            // from front till back (or items.Length - 1)
            for (uint i = _front; i < _back; i++)
            {
                newItems[i - _front] = _items[i];
            }

            _items = newItems;
            _back -= _front;
            _front = 0;
        }

        _items[_back] = item;
        _back++;
    }
    private T[] Grow()
    /// summary>Resize the array to double the current size.</summary>
    /// <returns>The new array with the resized capacity.</returns>
    {
        var newItems = _items.Length <= Size * ResizeFactor ? new T[_items.Length * ResizeFactor] : _items;
        Capacity = (uint)newItems.Length;
        return newItems;
    }

    /// <summary>Remove and return the next item in the queue</summary>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    /// <returns>The next item in the queue.</returns>
    public T Dequeue()
    {
        if (Size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var item = _items[_front];
        if (_front >= _back)
        {
            _front = _back;
        }
        else
        {
            _front++;
        }

        return item;
    }
}

