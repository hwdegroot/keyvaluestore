using Common.Domain;

namespace Common.Test.Domain;

[TestClass]
public class ArrayQueueTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyQueueWillNotPop()
    {
        var queue = new ArrayQueue<int>();

        queue.Dequeue();
    }

    [TestMethod]
    public void QueueWillDequeueItemsInOrder()
    {
        var queue = new ArrayQueue<int>(100);
        for (var i = 0; i < 100; i++)
        {
            queue.Enqueue(i);
        }

        for (var i = 0; i < 100; i++)
        {
            Assert.AreEqual((uint)(100 - i), queue.Size);
            Assert.AreEqual(i, queue.Dequeue());
        }
        Assert.AreEqual((uint)0, queue.Size);
    }

    [TestMethod]
    public void QueueWillResizeWhenLimitReached()
    {
        var queue = new ArrayQueue<int>();
        for (var i = 0; i < 100; i++)
        {
            queue.Enqueue(i);
        }

        for (var i = 0; i < 100; i++)
        {
            Assert.AreEqual((uint)(100 - i), queue.Size);
            Assert.AreEqual(i, queue.Dequeue());
        }
        Assert.AreEqual((uint)0, queue.Size);
    }

    [TestMethod]
    public void QueueWillKeepSteadySizeWhenPushPoppingItems()
    {
        var queue = new ArrayQueue<int>(20);
        for (var i = 0; i < 20; i++)
        {
            queue.Enqueue(i);
            if (i % 2 == 0)
            {
                Assert.AreEqual((uint)(i / 2 + 1), queue.Size);
                Assert.AreEqual(i / 2, queue.Dequeue());

            }

        }
        Assert.AreEqual((uint)10, queue.Size);
    }

    [TestMethod]
    public void QueueWillKeepSteadySizeWhenPushPoppingItemsWithResize()
    {
        var queue = new ArrayQueue<int>(20);
        for (var i = 1; i <= 1000; i++)
        {
            queue.Enqueue(i);
            if (i % 2 == 0)
            {
                Assert.AreEqual((uint)(i / 2 + 1), queue.Size);
                Assert.AreEqual(i / 2, queue.Dequeue());

            }

        }
        Assert.AreEqual((uint)500, queue.Size);
    }
}

