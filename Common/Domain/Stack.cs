namespace Common.Domain;

// Implements the last-in-first-out (LIFO) stack data-structure.
// Items are added and removed from the top of the stack only.
public class Stack<T> : IStack<T>
{
    private Item<T>? _front = null;
    private Item<T>? _back = null;
    private uint _size = 0;
    public uint Size => _size;

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

    public T Peek()
    {
        if (_front == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _front.Value;
    }

    public T Pop()
    {
        if (_front == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = _front.Value;
        _front = _front.Next;

        if (_front != null)
            _front.Previous = null;

        _size--;

        return item;
    }
}
