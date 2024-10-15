namespace Common.Domain;
// Implements the last-in-first-out (LIFO) stack data-structure.
// Items are added and removed from the top of the stack only.
public interface IStack<T>
{
    uint Size { get; }

    void Push(T item);
    T Peek();
    T Pop();
}

