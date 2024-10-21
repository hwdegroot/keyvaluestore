using Common.Domain;

namespace Common.Test.Domain;

[TestClass]
public class LinkedStackTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyStackWillNotPop()
    {
        var stack = new LinkedStack<int>();

        stack.Pop();
    }

    [TestMethod]
    public void StackWillPopItemsInOrder()
    {
        var stack = new LinkedStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.AreEqual((uint)3, stack.Size);
        Assert.AreEqual(3, stack.Peek());
        Assert.AreEqual(3, stack.Pop());

        Assert.AreEqual((uint)2, stack.Size);
        Assert.AreEqual(2, stack.Peek());
        Assert.AreEqual(2, stack.Pop());

        Assert.AreEqual((uint)1, stack.Size);
        Assert.AreEqual(1, stack.Pop());

        Assert.AreEqual((uint)0, stack.Size);
    }

    [TestMethod]
    public void TraverseQueueBackAndForthShouldPeekRightItems()
    {
        var stack = new LinkedStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var cursor = stack.Current();

        Assert.AreEqual(3, cursor!.Value);
        cursor = cursor.Next;
        Assert.AreEqual(2, cursor!.Value);
        cursor = cursor.Next;
        Assert.AreEqual(1, cursor!.Value);

        Assert.IsNull(cursor.Next);

        cursor = cursor.Previous;
        Assert.AreEqual(2, cursor!.Value);
        cursor = cursor.Previous;
        Assert.AreEqual(3, cursor!.Value);

        Assert.IsNull(cursor.Previous);
    }
}
