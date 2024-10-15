namespace Common.Domain;

public class Queue<T> : IQueue<T>
{
    private Item<T>? _front = null;
    private Item<T>? _back = null;
    private uint _size = 0;
    public uint Size => _size;

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

    public T Dequeue()
    {
        if (_front == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var item = _front.Value;
        _front = _front.Next;
        if (_front != null)
        {
            _front.Previous = null;
        }

        _size--;
        return item;
    }

    public Item<T>? Current()
    {
        return _front;
    }
}
