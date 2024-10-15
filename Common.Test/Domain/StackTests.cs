namespace Common.Test.Domain;

[TestClass]
public class StackTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyStackWillNotPop()
    {
        var stack = new Common.Domain.Stack<int>();

        stack.Pop();
    }

    [TestMethod]
    public void StackWillPopItemsInOrder()
    {
        var stack = new Common.Domain.Stack<int>();

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
}