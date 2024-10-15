namespace Common.Test.Domain;

[TestClass]
public class QueueTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyQueueWillNotPop()
    {
        var queue = new Common.Domain.Queue<int>();

        queue.Dequeue();
    }

    [TestMethod]
    public void QueueWillPopItemsInOrder()
    {
        var queue = new Common.Domain.Queue<int>();

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
}
