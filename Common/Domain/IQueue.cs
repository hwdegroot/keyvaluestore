namespace Common.Domain;
// Implements the first-in-first-out (FIFO) queue data-structure.
// Items are added to the queue at the "back" and removed from the "front".
public interface IQueue<T>
{
    uint Size { get; }

    void Enqueue(T item);
    T Dequeue();
}
