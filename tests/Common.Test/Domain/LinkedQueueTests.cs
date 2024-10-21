using Common.Domain;

namespace Common.Test.Domain;

[TestClass]
public class LinkedQueueTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyQueueWillNotPop()
    {
        var queue = new LinkedQueue<int>();

        queue.Dequeue();
    }

    [TestMethod]
    public void QueueWillPopItemsInOrder()
    {
        var queue = new LinkedQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);


        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual((uint)2, queue.Size);
        Assert.AreEqual(2, queue.Dequeue());
        Assert.AreEqual((uint)1, queue.Size);
        Assert.AreEqual(3, queue.Dequeue());
        Assert.AreEqual((uint)0, queue.Size);
    }

    [TestMethod]
    public void TraverseQueueBackAndForthShouldPeekRightItems()
    {
        var queue = new LinkedQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        var cursor = queue.Current();

        Assert.AreEqual(1, cursor!.Value);
        cursor = cursor.Next;
        Assert.AreEqual(2, cursor!.Value);
        cursor = cursor.Next;
        Assert.AreEqual(3, cursor!.Value);

        Assert.IsNull(cursor.Next);

        cursor = cursor.Previous;
        Assert.AreEqual(2, cursor!.Value);
        cursor = cursor.Previous;
        Assert.AreEqual(1, cursor!.Value);

        Assert.IsNull(cursor.Previous);
    }

}
