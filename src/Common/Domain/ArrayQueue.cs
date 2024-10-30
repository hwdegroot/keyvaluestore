namespace Common.Domain;

public class ArrayQueue<T> : IQueue<T>
{
    private int _initailCapacity;
    private T[] _items;
    // index of the first item in the queue
    private uint _front = 0;
    // index of the last item in the queue
    private uint _back = 0;
    private uint _size = 0;
    public uint Size => _size;

    public ArrayQueue(int initialCapacity = 10)
    {
        _initailCapacity = initialCapacity;
        _items = new T[_initailCapacity];
    }

    /// <summary>Push a new item onto the queue.</  summary>
    /// <param name="item">The item to queue.</param>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    public void Enqueue(T item)
    {
        if (_back == _items.Length)
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
            var newItems = _items.Length <= _size * 2 ? new T[_items.Length * 2] : _items;
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
        _size = _back - _front;
    }

    /// <summary>Remove and return the next item in the queue</summary>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception
    /// <returns>The next item in the queue.</returns>
    public T Dequeue()
    {

        ThrowIfEmpty();

        var item = _items[_front];
        if (_front >= _back)
        {
            _size = 0;
            _front = _back;
        }
        else
        {
            _front++;
            _size--;
        }

        return item;
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

